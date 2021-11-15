using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin; // the coin we're going to spawn
    public int XBounds; // these will be our boundry for the game
    public int YBounds;

    public float Timer;
    public float SpawnCoinTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer >= SpawnCoinTime) // when timer hits our spawn time
        {
            int randomX = Random.Range(-XBounds, XBounds + 1); // find a spot inside our x bounds
            int randomY = Random.Range(-YBounds, YBounds + 1); // find a spot inside our y bounds

            Instantiate(Coin, new Vector3(transform.position.x + randomX, transform.position.y + randomY), Quaternion.identity); // we spawn the coin using a new vector3 for position and 0 rotation

            Timer = 0; // reset the timer
        }
        Timer += Time.deltaTime; // increment, or add time to our timer
    }
}
