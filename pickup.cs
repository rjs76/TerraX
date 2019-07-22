using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private inventory inventory1;
    public GameObject itemButton;
    // Start is called before the first frame update
    private void Start()
    {
        inventory1 = GameObject.FindGameObjectsWithTag("Player").GetComponent<inventory>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            for(int i=0; i< inventory1.slots.Length; i++)
            {
                if(inventory1.isFull[i] == false)
                {
                    inventory1.isFull[i] = true;
                    Instantiate(itemButton, inventory1.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

}
