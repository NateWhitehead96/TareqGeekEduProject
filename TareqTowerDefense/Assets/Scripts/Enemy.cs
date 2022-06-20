using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public MazePoints maze; // for access to the path points
    public int moveSpeed; // how fast the enemy moves
    public int health; // how much beef the enemy has
    public int currentPoint; // the enemy knows what point to move to
    // Start is called before the first frame update
    void Start()
    {
        maze = FindObjectOfType<MazePoints>(); // set maze to be the gameobject that has the script
    }

    // Update is called once per frame
    void Update()
    {
        // move from our position, the point we move to is from our list os points, move at speed * time
        transform.position = Vector3.MoveTowards(transform.position, maze.Points[currentPoint].position, moveSpeed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, maze.Points[currentPoint].position); // what is the distance from us to point
        if(distance <= 0.1f) // if the enemy gets really close to the point
        {
            currentPoint++; // make us go to the next point in the array
        }
        if(currentPoint >= maze.Points.Length) // if the enemy has reached the end of the checkpoints
        {
            Destroy(gameObject);
        }
        if(health <= 0) // if the enemy dies
        {
            FindObjectOfType<TowerManager>().gold += 5; // award money
            Destroy(gameObject); // kill enemy
        }
    }
}
