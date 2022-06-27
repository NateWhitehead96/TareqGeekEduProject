using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy; // the enemy we want to spawn
    public float timer; // how fast the enemies get spawned

    public int enemiesRemaining; // how many enemies are left to spawn
    public int wave; // what wave we're on
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        enemiesRemaining = 5 * wave;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 2 && enemiesRemaining > 0) // every 2 seconds spawn an enemy if we also have enemies to spawn
        {
            GameObject newEnemy = Instantiate(Enemy, transform.position, transform.rotation); // spawn enemy
            newEnemy.GetComponent<Enemy>().health += wave; // buff enemies hp every wave
            enemiesRemaining--; // so we take away an enemy when we spawn 1
            timer = 0; // reset timer
            if(enemiesRemaining == 0)
            {
                StartCoroutine(StartNextWave()); // when we run out of enemies start our next wave
            }
        }
        timer += Time.deltaTime; // increase time
    }

    IEnumerator StartNextWave() 
    {
        yield return new WaitForSeconds(10); // wait 10 seconds
        wave++; // increase wave number
        enemiesRemaining += wave * 5; // every wave our enemies increase by 5
    }
}
