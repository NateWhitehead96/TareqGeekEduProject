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
                if(collision.gameObject.GetComponent<PlayerInventory>().InventorySlots[i].currentItem == itemType) // if the item on the ground is in our inventory, stack it
                {
                    itemType.quantity++; // add to the quantity or number of items
                    if(itemType == collision.gameObject.GetComponent<PlayerInventory>().gem) // if the item we're picking up is a gem add to player gems
                    {
                        PlayerInventory.Gems++;
                    }
                    Destroy(gameObject);
                    return;
                }
                if(collision.gameObject.GetComponent<PlayerInventory>().InventorySlots[i].currentItem == collision.gameObject.GetComponent<PlayerInventory>().defaultItem)
                {
                    itemType.quantity++; 
                    if (itemType == collision.gameObject.GetComponent<PlayerInventory>().gem) // if the item we're picking up is a gem add to player gems
                    {
                        PlayerInventory.Gems++;
                    }
                    collision.gameObject.GetComponent<PlayerInventory>().InventorySlots[i].UpdateSlot(itemType, itemType.quantity); // the item we're walking into now goes into hopefully the empty slot
                    collision.gameObject.GetComponent<PlayerInventory>().InventorySlots[i].hasItem = true;
                    Destroy(gameObject);
                    return;
                }
                
            }
        }
    }
}
