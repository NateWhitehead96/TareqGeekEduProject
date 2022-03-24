using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Health++; // increase player hp
            if(collision.gameObject.GetComponent<PlayerScript>().Health >= 3) // if they player is at max hp then set it to 3
            {
                collision.gameObject.GetComponent<PlayerScript>().Health = 3;
            }
            Destroy(gameObject); // destroy heart
        }
    }
}
