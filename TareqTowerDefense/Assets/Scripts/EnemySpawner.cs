using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy; // the enemy we want to spawn
    public float timer; // how fast the enemies get spawned

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 2) // every 2 seconds spawn an enemy
        {
            Instantiate(Enemy, transform.position, transform.rotation); // spawn enemy
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // increase time
    }
}
