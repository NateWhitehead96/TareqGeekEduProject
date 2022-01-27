using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite image; // the image of our item
    public int quantity; // how many of the items
}
