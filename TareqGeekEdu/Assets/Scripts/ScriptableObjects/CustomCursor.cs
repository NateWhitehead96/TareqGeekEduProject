using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    public Image cursorImage; // the picture on the cursor
    public PlayerInventory inventory; // access to player inventory
    public Item currentItem; // the item on the cursor
    public Slots currentSlot; // access to the slot 
}
