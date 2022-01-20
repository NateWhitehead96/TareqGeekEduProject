using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Text DisplayText; // this will show what items we have
    // our 3 heart displays
    public Image LifeOne;
    public Image LifeTwo;
    public Image LifeThree;

    public PlayerScript player; // we have access to our player script for the health

    public GameObject GameOverCanavs;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>(); // this makes sure the player is the one from the scene
        GameOverCanavs.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText.text = "Logs: " + PlayerInventory.Logs + "\n" + "Rocks: " + PlayerInventory.Stones; // this will show how many logs we have and on the next line how many rocks we have

        if(player.Health < 3)
        {
            LifeThree.rectTransform.rotation = Quaternion.Euler(0, 0, 180); // when we are lower then 3 health, rotate the 3rd heart upside down
        }
        if (player.Health < 2)
        {
            LifeTwo.rectTransform.rotation = Quaternion.Euler(0, 0, 180); // when we are lower then 3 health, rotate the 3rd heart upside down
        }
        if(player.Health <= 0)
        {
            Time.timeScale = 0;
            GameOverCanavs.SetActive(true);
        }
    }
}
