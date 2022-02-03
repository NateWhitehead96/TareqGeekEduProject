using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static int Logs; // the total number of our logs
    public static int Stones; // the total number of our stones

    public Slots[] InventorySlots; // all the slots on our inventory

    public Item wood;
    public Item rock;
    public Item defaultItem;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < InventorySlots.Length; i++) // assign all of the slots to defualt
        {
            InventorySlots[i].UpdateSlot(defaultItem);
        }

        InventorySlots[0].UpdateSlot(wood); // updating the slot for wood

        InventorySlots[1].UpdateSlot(rock);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlots[i].UpdateSlot(InventorySlots[i].currentItem); // the inventory will constantly update itself
        }
    }
}
