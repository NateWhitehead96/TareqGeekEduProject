using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPickup : MonoBehaviour
{
    public GameObject HammerIcon; // the icon on the toolbelt
    public PlayerScript player; // to know if player has hammer
    // Start is called before the first frame update
    void Start()
    {
        //HammerIcon.SetActive(false); // make sure to hide it to start
        player = FindObjectOfType<PlayerScript>();
        if(player.ownHammer == true)
        {
            HammerIcon.SetActive(true); // set icon true
            Destroy(gameObject); // kill off the hammer in scene
        }
        else if(player.ownHammer == false)
        {
            HammerIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //PlayerScript player = collision.gameObject.GetComponent<PlayerScript>(); // so we have access to player script stuff
            player.ownHammer = true; // switch own bool to true
            player.EquipHammer(); // equip the hammer right away
            HammerIcon.SetActive(true); // display the icon
            Destroy(gameObject); // destroy the hammer on the ground
        }
    }
}
