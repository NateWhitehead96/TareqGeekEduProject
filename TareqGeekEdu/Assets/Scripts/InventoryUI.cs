using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Text DisplayText; // this will show what items we have
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText.text = "Logs: " + PlayerInventory.Logs + "\n" + "Rocks: " + PlayerInventory.Stones; // this will show how many logs we have and on the next line how many rocks we have
    }
}
