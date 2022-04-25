using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootSide
{
    Up,
    Right,
    Down,
    Left
}

public class BossBullet : MonoBehaviour
{
    public ShootSide side; // know what side the bullet is coming from
    public int moveSpeed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(side == ShootSide.Up) // if the bullet is spawned and is set to go up
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        if (side == ShootSide.Right) // if the bullet is spawned and is set to go right
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        if (side == ShootSide.Down) // if the bullet is spawned and is set to go down
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
        if (side == ShootSide.Left) // if the bullet is spawned and is set to go left
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
