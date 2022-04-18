using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingBlob : EnemyScript
{
    public GameObject Blob;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.maxValue = Health;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, Player.position);
        if (stunned == false)
            transform.position = Vector3.Lerp(transform.position, MovePosition, Time.deltaTime);
        if (distance < 20 && stunned == false)
        {
            MovePosition = Player.position; // set the move to position to be the player

        }
        if (timer > 5)
        {
            float x = Random.Range(transform.position.x - 20, transform.position.x + 20);
            float y = Random.Range(transform.position.y - 20, transform.position.y + 20);
            MovePosition = new Vector3(x, y, 0);
            Instantiate(Blob, transform.position, transform.rotation); // spawn a new enemy
            timer = 0;
        }
        timer += Time.deltaTime;

        if (distance < 3f && attacking == false) // within the attack range
        {
            StartCoroutine(AttackPlayer());
        }

        HealthBar.value = Health;

        if (Health <= 0)
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
}
