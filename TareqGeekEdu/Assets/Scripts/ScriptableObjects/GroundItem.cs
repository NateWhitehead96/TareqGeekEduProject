using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public Item itemType; // what kind of item is it
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < collision.gameObject.GetComponent<PlayerInventory>().InventorySlots.Length; i++)
            {
                if(collision.gameObject.GetComponent<PlayerInventory>().InventorySlots[i].hasItem == false)
                {
                    collision.gameObject.GetComponent<PlayerInventory>().InventorySlots[i].UpdateSlot(itemType); // the item we're walking into now goes into hopefully the empty slot
                    collision.gameObject.GetComponent<PlayerInventory>().InventorySlots[i].hasItem = true;
                    Destroy(gameObject);
                    return;
                }
                
            }
        }
    }
}
