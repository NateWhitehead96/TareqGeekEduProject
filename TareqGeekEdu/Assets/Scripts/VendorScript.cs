using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorScript : MonoBehaviour
{
    public Text VendorText; // what the vendor can say to our player
    public PlayerScript player; // access to the player
    public GameObject VendorCanvas; // to help hide or show the canvas
    public GameObject UpgradeMenu; // the menu that has buttons to upgrade our items
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>(); // just to make sure our player is linked to this script (optional)
        VendorCanvas.SetActive(false); // hide the canvas on start
        UpgradeMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VendorCanvas.SetActive(true); // show the vendor store
            VendorText.text = "Hello adventurer, i offer fine wares. Would you like to buy a sword for 3 wood and 3 stone."; // optional
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // when the player leaves the shop
    {
        VendorCanvas.SetActive(false); // hide canvas
        UpgradeMenu.SetActive(false);
    }

    public void BuySword()
    {
        if (PlayerInventory.Logs >= 3 && PlayerInventory.Stones >= 3 && player.ownSword == false) // we have enough logs and stone and player doesnt have sword
        {
            PlayerInventory.Logs -= 3;
            PlayerInventory.Stones -= 3;
            player.ownSword = true; // now we own the sword
            player.SwordIcon.SetActive(true); // display the sword icon on our tool belt
            VendorText.text = "Tee hee hee, looks like you got yourself a powerful new weapon.";
        }
        else
            VendorText.text = "You don't have the resources to buy the sword nub.";
    }

    public void ExitVendor()
    {
        VendorCanvas.SetActive(false); // hide the canvas
    }

    public void ShowUpgradeMenu()
    {
        VendorCanvas.SetActive(false); // hide the buy sword interface
        UpgradeMenu.SetActive(true);
    }
    public void ShowVenderMenu()
    {
        VendorCanvas.SetActive(true); // hide the buy sword interface
        UpgradeMenu.SetActive(false);
    }

    public void UpgradeSword() // upgrade sword
    {
        if(PlayerInventory.Gems > 0)
        {
            PlayerInventory.Gems--; // at the cost of 1 gem, increase our sword level
            player.swordLevel++;
            player.AllTools[2].GetComponent<SpriteRenderer>().sprite = player.GemSword; // assigning the sword sprite to the gemsword
        }
    }
}
