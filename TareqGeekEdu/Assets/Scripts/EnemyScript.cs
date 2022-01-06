using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Player; // know the players location
    public float movespeed; // how fast the enemy can move
    public float DistanceX; // how far the player is from the enemy on the x axis
    public float DistanceY; // how far the player is from the enemy on the y axis

    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceX = Mathf.Abs(transform.position.x - Player.position.x); // this now is the absolute distance
        DistanceY = Mathf.Abs(transform.position.y - Player.position.y);

        if (DistanceX < 20 && DistanceY < 20)
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

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
