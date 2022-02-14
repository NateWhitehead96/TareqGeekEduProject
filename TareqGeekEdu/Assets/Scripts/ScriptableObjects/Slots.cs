using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour , IDragHandler, IDropHandler, IBeginDragHandler
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

    public void UpdateSlot(Item item, int amount)
    {
        currentItem = item; // make the item coming into the slot the new current item
        currentItem.quantity = amount;
        image.sprite = currentItem.image; // set the image
        quantity.text = currentItem.quantity.ToString(); // update the text
        
        //hasItem = true; // again this is bad
    }

    public void OnDrag(PointerEventData eventData)
    {
        customCursor.transform.position = Input.mousePosition; // the cursor moves with our mouse position
        currentItem = inventory.defaultItem; // wipe the old slot to be the default item
    }

    public void OnDrop(PointerEventData eventData)
    {
        for (int i = 0; i < inventory.InventorySlots.Length; i++)
        {
            if(RectTransformUtility.RectangleContainsScreenPoint(inventory.InventorySlots[i].GetComponent<RectTransform>(), Input.mousePosition) 
                && inventory.InventorySlots[i].currentItem == inventory.defaultItem) // check that we're moving an item into the empty slot
            {
                inventory.InventorySlots[i].currentItem = customCursor.currentItem; // dropping the item on our cursor onto the slot
                customCursor.cursorImage.color = Color.clear; // hiding cursor
                print("Dropping Item on slot");
            }
            else if(RectTransformUtility.RectangleContainsScreenPoint(inventory.InventorySlots[i].GetComponent<RectTransform>(), Input.mousePosition)
                && inventory.InventorySlots[i].currentItem != inventory.defaultItem) // this means the item we're dropping on isnt empty
            {
                customCursor.currentSlot.currentItem = inventory.InventorySlots[i].currentItem; // assigns the slot to be the item we're switching
                inventory.InventorySlots[i].currentItem = customCursor.currentItem; // assigns the drop slot to be the item on cursor
                customCursor.cursorImage.color = Color.clear; // hide cursor
            }
        }
        customCursor.cursorImage.color = Color.clear; // hide cursor
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        customCursor.cursorImage.color = Color.white; // make the image visible
        customCursor.cursorImage.sprite = image.sprite; // assign the slots image to our cursor
        customCursor.currentSlot = GetComponent<Slots>(); // assign the slot to our cursor
        customCursor.currentItem = currentItem; // assign the item to our cursor
    }
}
