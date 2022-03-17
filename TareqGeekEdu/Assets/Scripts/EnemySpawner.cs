using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    public void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}
