using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // the thing we use in other scripts to access this script

    private void Awake()
    {
        if(instance != null) // meaning we already have a instance of the Game manager
        {
            Destroy(gameObject); // this version
        }
        else // we dont have an active game manager
        {
            instance = this; // set this script to be the active game manager
            DontDestroyOnLoad(gameObject); // allow this thing to move between all of the scenes
        }
    }
    
    public void SaveGame() // this function will load important data
    {
        PlayerScript player = FindObjectOfType<PlayerScript>(); // we now have access to all of the player script things

        if (player.ownSword) // if we own the sword
        {
            PlayerPrefs.SetInt("ownSword", 1); // using the saving class PlayerPrefs to save and int called ownSword and it's value
        }
        else // we dont
        {
            PlayerPrefs.SetInt("ownSword", 0); // if we dont have the sword make value 0
        }
        if (player.ownHammer) // if we own the hammer
        {
            PlayerPrefs.SetInt("ownHammer", 1); 
        }
        else
        {
            PlayerPrefs.SetInt("ownHammer", 0);
        }
    }

    public void LoadGame() // this function loads all of our stuff
    {
        PlayerScript player = FindObjectOfType<PlayerScript>();
        if (PlayerPrefs.HasKey("ownSword")) // to check to make sure we have a saved file already
        {
            if(PlayerPrefs.GetInt("ownSword") == 1) // we owned the sword in a previous game
            {
                player.ownSword = true;
            }
            if(PlayerPrefs.GetInt("ownHammer") == 1) // we owned the hammer in a previous game
            {
                player.ownHammer = true;
            }
        }
    }
}
