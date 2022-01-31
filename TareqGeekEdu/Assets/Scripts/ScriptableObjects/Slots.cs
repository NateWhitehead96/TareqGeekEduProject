using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Image image; // the image of the inventory slot
    public Text quantity; // the amount of the items
    public Item currentItem; // the current item in the slot
    public bool hasItem; // tell us if there is an item or not

    public void UpdateSlot(Item item)
    {
        currentItem = item; // make the item coming into the slot the new current item
        image.sprite = currentItem.image; // set the image
        quantity.text = currentItem.quantity.ToString(); // update the text
        
        //hasItem = true; // again this is bad
    }
}
