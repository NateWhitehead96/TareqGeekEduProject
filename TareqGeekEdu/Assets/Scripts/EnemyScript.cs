using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Transform Player; // know the players location
    public Transform MovePosition; // new position to move to
    public float movespeed; // how fast the enemy can move
    public float distance; // distance from player to enemy

    public int Health;
    public Slider HealthBar;

    public bool stunned;

    public LayerMask playerLayer;
    public bool attacking;

    public GameObject Gem; // the prefab gem we're going to drop when enemy dies

    public float timer; // this will count down to move the enemy randomly
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.maxValue = Health;
        MovePosition = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //DistanceX = Mathf.Abs(transform.position.x - Player.position.x); // this now is the absolute distance
        //DistanceY = Mathf.Abs(transform.position.y - Player.position.y);
        distance = Vector3.Distance(transform.position, Player.position);

        transform.position = Vector3.Lerp(transform.position, MovePosition.position, Time.deltaTime);
        if (distance < 20 && stunned == false)
        {
            MovePosition.position = Player.position; // set the move to position to be the player
            // we are close enough to the player to chase
            //if(transform.position.x < Player.position.x) // enemy is to the left of the player
            //{
            //    transform.position = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
            //}
            //if(transform.position.x > Player.position.x) // enemy is to the right of the player
            //{
            //    transform.position = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
            //}
            //if(transform.position.y < Player.position.y) // the enemy is below the player
            //{
            //    transform.position = new Vector3(transform.position.x, transform.position.y + movespeed * Time.deltaTime);
            //}
            //if (transform.position.y > Player.position.y) // the enemy is above the player
            //{
            //    transform.position = new Vector3(transform.position.x, transform.position.y - movespeed * Time.deltaTime);
            //}
        }
        else if (timer > 5)
        {
            float x = Random.Range(transform.position.x - 20, transform.position.x + 20);
            float y = Random.Range(transform.position.y - 20, transform.position.y + 20);
            MovePosition.position = new Vector3(x, y, 0);
            timer = 0;
        }
        timer += Time.deltaTime;

        if(distance < 2 && attacking == false) // within the attack range
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
