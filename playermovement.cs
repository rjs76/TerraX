using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    float velx;
    float vely;
    bool facingRight = true;

    private Rigidbody2D rb2d;
    public int speed;
    public float jumpForce;
    public bool OnGround = true;
    //public Animator animator;
    //float horizontalmove=0f;

    public KeyCode left;
    public KeyCode right;
    public KeyCode Jump;
    public KeyCode Fire1;

    public Transform spawnpoint;

    public Transform groundCheckPoint;
    // public float groundCheckRadius;
    // public LayerMask whatisGround;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //OnGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatisGround);

        //Horizontal Movement
        float movex = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(left))
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //  facingRight = true;

        }
        else if (Input.GetKey(right))
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //  facingRight = false;
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKeyDown(Jump) && OnGround)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        
        //animator
        // animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        // hDebug.Log(animator.GetFloat("Speed"));

        //  animator.SetFloat("Jumping", Mathf.Abs(rb2d.velocity.y));

        // if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        //{
        //   rb2d.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

        //}

    }
    //which direcction the character is facing 
    void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (velx > 0)
        {

            facingRight = true;

        }
        else if (velx < 0)
        {

            facingRight = false;

        }
        if ((facingRight && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("platform"))
        {
            OnGround = true;
            //   animator.SetBool("IsJumping", true);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            if (playerlives.health == 0)
            {
                respawn();
            }
        }
        if (collision.gameObject.tag.Equals("Death"))
        {
            if (playerlives.health == 0)
            {
                respawn();
            }

        }
        if (collision.gameObject.tag.Equals("endgoal"))
        {
            SceneManager.LoadScene("playermenu");
            //SceneManager.LoadScene("level2");
        }
        //if (collision.gameObject.tag.Equals("warp"))
        //  {
        //      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //  }
    }

    // public void OnLanding()
    // {
    //      animator.SetBool("IsJumping", false);
    //     OnGround = false;
    //  }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            //     animator.SetBool("IsJumping", false);
            OnGround = false;
        }
    }

    public void respawn()
    {
        //this.transform.position = new Vector3(-1.5f, -0.5f, -48.0f);
        //this.transform.position = spawnpoint.position;
        SceneManager.LoadScene("level1");
    }

}

