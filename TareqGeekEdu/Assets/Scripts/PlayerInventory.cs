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
            InventorySlots[i].image.sprite = defaultItem.image;
            InventorySlots[i].quantity.text = defaultItem.quantity.ToString();
        }

        InventorySlots[0].image.sprite = wood.image; // assign the wood image to the first slot
        InventorySlots[0].quantity.text = wood.quantity.ToString(); // assign the text of the item slot to our item

        InventorySlots[1].image.sprite = rock.image;
        InventorySlots[1].quantity.text = rock.quantity.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        wood.quantity = Logs; // make sure our logs are updating
        InventorySlots[0].quantity.text = wood.quantity.ToString();
        rock.quantity = Stones; // make sure our stones are updating
        InventorySlots[1].quantity.text = rock.quantity.ToString();
    }
}
