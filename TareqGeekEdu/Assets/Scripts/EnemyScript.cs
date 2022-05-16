using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyScript : MonoBehaviour
{
    public Transform Player; // know the players location
    public Vector3 MovePosition; // new position to move to
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
        MovePosition = transform.position;
        Player = FindObjectOfType<PlayerScript>().transform; // assign the player to every enemy that gets spawned
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, Player.position);
        if(stunned == false)
            transform.position = Vector3.Lerp(transform.position, MovePosition, Time.deltaTime);
        if (distance < 20 && stunned == false)
        {
            MovePosition = Player.position; // set the move to position to be the player
            
        }
        else if (timer > 5)
        {
            float x = Random.Range(transform.position.x - 20, transform.position.x + 20);
            float y = Random.Range(transform.position.y - 20, transform.position.y + 20);
            MovePosition = new Vector3(x, y, 0);
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
                SoundManager.instance.PlayerHurt.Play();
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
        yield return new WaitForSeconds(1f); // wait 1 seconds
        stunned = false;
    }
}
