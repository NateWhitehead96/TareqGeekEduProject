using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static int Logs; // the total number of our logs
    public static int Stones; // the total number of our stones
    public static int Gems; // the total number of our gems

    public Slots[] InventorySlots; // all the slots on our inventory

    public Item wood;
    public Item rock;
    public Item gem;
    public Item defaultItem;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < InventorySlots.Length; i++) // assign all of the slots to defualt
        {
            InventorySlots[i].UpdateSlot(defaultItem, 0);
        }

        InventorySlots[0].UpdateSlot(wood, Logs); // updating the slot for wood

        InventorySlots[1].UpdateSlot(rock, Stones);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if(InventorySlots[i].currentItem == wood) // update logs
            {
                InventorySlots[i].UpdateSlot(InventorySlots[i].currentItem, Logs); // the inventory will constantly update itself
            }
            if (InventorySlots[i].currentItem == rock) // update rocks
            {
                InventorySlots[i].UpdateSlot(InventorySlots[i].currentItem, Stones); // the inventory will constantly update itself
            }
            if (InventorySlots[i].currentItem == gem) // update gems
            {
                InventorySlots[i].UpdateSlot(InventorySlots[i].currentItem, Gems); // the inventory will constantly update itself
            }
            if (InventorySlots[i].currentItem == defaultItem) // update defaults
            {
                InventorySlots[i].UpdateSlot(InventorySlots[i].currentItem, 0); // the inventory will constantly update itself
            }
        }
    }
}
