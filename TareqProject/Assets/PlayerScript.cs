using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    
    public int moveSpeed;
    public int score;
    public int health; // our health variable
    public float XBounds; // our x boundary
    public float YBounds; // our y boundary

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) && transform.position.y < YBounds) // moving up
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) && transform.position.y > -YBounds) // moving down
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -XBounds) // moving left
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) && transform.position.x < XBounds) // right
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }

        if(health <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))  // when we collect the coin
        {
            score++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Hazard"))
        {
            health--;
            Destroy(collision.gameObject);
        }

    }

}
