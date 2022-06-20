using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target; // target the projectile is going to
    public float moveSpeed; // how fast it goes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) // if the enemy is dead, lets also destroy our projectile
        {
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); // move proj
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().health--; // when the projectile hits an enemy, deal damage
            Destroy(gameObject); // destroy the projectile
        }
    }
}
