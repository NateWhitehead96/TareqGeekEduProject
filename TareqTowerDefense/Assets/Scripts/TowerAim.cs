using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAim : MonoBehaviour
{
    public GameObject projectile; // the bullet the tower is shooting
    public List<GameObject> enemiesInRange; // a dynamic list of what enemies are near
    public float reloadTime; // whats the reload time
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInRange.Count <= 0) return; // stop doing any code if there are no nearby enemies

        for (int i = 0; i < enemiesInRange.Count; i++) // loops through our enemies in range
        {
            if (enemiesInRange[i] == null) // if one is dead, then we remove it from the list
            {
                enemiesInRange.RemoveAt(i);
            }
        }

        // shoot porjectile stuff
        if(timer >= reloadTime)
        {
            GameObject proj = Instantiate(projectile, transform.position, transform.rotation); // spawn the projectile
            proj.GetComponent<Projectile>().target = enemiesInRange[0].transform; // set target of projectile to enemy
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; 

        // Rotation stuff
        Vector3 lookDirection = enemiesInRange[0].transform.position - transform.position; // finding the look direction
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; // finding the angle
        transform.rotation = Quaternion.Euler(0, 0, angle); // apply the angle to our rotation
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject); // to see if anything collides
        if (collision.gameObject.GetComponent<Enemy>()) // add any enemy that comes into our attack radius
        {
            enemiesInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // subtract the enemy when they leave our attack radius
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }
}
