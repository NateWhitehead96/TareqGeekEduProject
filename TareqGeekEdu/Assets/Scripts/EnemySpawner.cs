using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    public void SpawnEnemy() // we'll call this function when we want to spawn the enemies
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}
