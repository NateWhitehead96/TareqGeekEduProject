using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    public int moveSpeed;
    public int score;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) // moving up
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s")) // moving down
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a")) // moving left
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey("d")) // right
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) 
        {
            score++;
            Destroy(collision.gameObject);
        }
    }

}
