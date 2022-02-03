using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour , IDragHandler, IDropHandler
{
    public Image image; // the image of the inventory slot
    public Text quantity; // the amount of the items
    public Item currentItem; // the current item in the slot
    public bool hasItem; // tell us if there is an item or not

    public CustomCursor customCursor; // a link to our cursor
    public PlayerInventory inventory; // the player inventory

    private void Start()
    {
        customCursor = FindObjectOfType<CustomCursor>();
        inventory = FindObjectOfType<PlayerInventory>();
        customCursor.cursorImage.color = Color.clear; // hide the cursor when we play
    }

    public void UpdateSlot(Item item)
    {
        currentItem = item; // make the item coming into the slot the new current item
        image.sprite = currentItem.image; // set the image
        quantity.text = currentItem.quantity.ToString(); // update the text
        
        //hasItem = true; // again this is bad
    }

    public void OnDrag(PointerEventData eventData)
    {
        customCursor.cursorImage.color = Color.white; // make the image visible
        customCursor.cursorImage.sprite = image.sprite; // assign the slots image to our cursor
        customCursor.transform.position = Input.mousePosition; // the cursor moves with our mouse position
        customCursor.currentItem = currentItem; // assign the item to our cursor
    }

    public void OnDrop(PointerEventData eventData)
    {
        for (int i = 0; i < inventory.InventorySlots.Length; i++)
        {
            if(RectTransformUtility.RectangleContainsScreenPoint(inventory.InventorySlots[i].GetComponent<RectTransform>(), Input.mousePosition))
            {
                inventory.InventorySlots[i].currentItem = customCursor.currentItem;
            }
        }
    }
}
