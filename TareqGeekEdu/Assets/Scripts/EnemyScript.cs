using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Transform Player; // know the players location
    public float movespeed; // how fast the enemy can move
    public float DistanceX; // how far the player is from the enemy on the x axis
    public float DistanceY; // how far the player is from the enemy on the y axis

    public int Health;
    public Slider HealthBar;

    public bool stunned;

    public LayerMask playerLayer;
    public bool attacking;

    public GameObject Gem; // the prefab gem we're going to drop when enemy dies
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.maxValue = Health;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceX = Mathf.Abs(transform.position.x - Player.position.x); // this now is the absolute distance
        DistanceY = Mathf.Abs(transform.position.y - Player.position.y);

        if (DistanceX < 20 && DistanceY < 20 && stunned == false)
        {
            // we are close enough to the player to chase
            if(transform.position.x < Player.position.x) // enemy is to the left of the player
            {
                transform.position = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
            }
            if(transform.position.x > Player.position.x) // enemy is to the right of the player
            {
                transform.position = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
            }
            if(transform.position.y < Player.position.y) // the enemy is below the player
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + movespeed * Time.deltaTime);
            }
            if (transform.position.y > Player.position.y) // the enemy is above the player
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - movespeed * Time.deltaTime);
            }
        }

        if(DistanceX < 2 && DistanceY < 2 && attacking == false) // within the attack range
        {
            StartCoroutine(AttackPlayer());
        }

        HealthBar.value = Health;

        if(Health <= 0)
        {
            Instantiate(Gem, transform.position, transform.rotation); // spawn gem
            Destroy(gameObject);
        }
    }

    IEnumerator AttackPlayer()
    {
        attacking = true;
        Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, 3, playerLayer); // find all objects on player layer
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i].gameObject.CompareTag("Player"))
            {
                player[i].gameObject.GetComponent<PlayerScript>().Health--;
            }
        }
        yield return new WaitForSeconds(1);
        attacking = false;
    }

    public void StunEnemy() // this function will help us stun and stop our enemy from moving
    {
        stunned = true;
        StartCoroutine(StunTime()); // starts a new timed event to unstun the enemy
    }

    IEnumerator StunTime()
    {
        yield return new WaitForSeconds(0.5f); // wait 0.5 seconds
        stunned = false;
    }
}
