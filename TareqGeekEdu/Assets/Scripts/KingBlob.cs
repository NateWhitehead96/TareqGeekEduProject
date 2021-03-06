using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // so we go between scenes

public class KingBlob : EnemyScript
{
    public GameObject Bullet; // the bullet we're shooting
    public ShootSide side; // side we're shooting
    public Transform[] shootPositions; // the positions we spawn the bullet at

    public GameObject WinCanvas; // holds the you win
    // Start is called before the first frame update
    void Start()
    {
        WinCanvas.SetActive(false); // hide on gamestart
        HealthBar.maxValue = Health;
        Player = FindObjectOfType<PlayerScript>().transform; // makes king blob know about player when it spawns
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, Player.position);
        if (stunned == false)
            transform.position = Vector3.Lerp(transform.position, MovePosition, Time.deltaTime);
        if (distance < 20 && stunned == false)
        {
            MovePosition = Player.position; // set the move to position to be the player

        }
        if (timer > 5)
        {
            float x = Random.Range(transform.position.x - 20, transform.position.x + 20);
            float y = Random.Range(transform.position.y - 20, transform.position.y + 20);
            MovePosition = new Vector3(x, y, 0);
            //spawn bullets
            SpawnBullets();
            timer = 0;
        }
        timer += Time.deltaTime;

        //if (distance < 3f && attacking == false) // within the attack range
        //{
        //    StartCoroutine(AttackPlayer());
        //}

        HealthBar.value = Health;

        if (Health <= 0)
        {
            Instantiate(Gem, transform.position, transform.rotation); // spawn gem
            //Destroy(gameObject);
            WinCanvas.SetActive(true); // show canvas
            Time.timeScale = 0; // pause
        }
    }

    public void ContinueSurviving()
    {
        Time.timeScale = 1; // reset time
        Destroy(gameObject); // kill king blob
    }

    public void LiveWithTrees()
    {
        // for now open main menu
        SceneManager.LoadScene(0);
    }

    IEnumerator AttackPlayer()
    {
        attacking = true;
        Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, 3, playerLayer); // find all objects on player layer
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i].gameObject.CompareTag("Player"))
            {
                player[i].gameObject.GetComponent<PlayerScript>().Health--;
                SoundManager.instance.PlayerHurt.Play();
                
            }
        }
        yield return new WaitForSeconds(1);
        attacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) // this will make blob bob hurt us only when he touches us
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Health--;
            SoundManager.instance.PlayerHurt.Play();
        }
    }

    void SpawnBullets()
    {
        // shooting first bullet
        GameObject newBullet = Instantiate(Bullet, shootPositions[0].position, shootPositions[0].rotation); // spawn bullet 1
        side = ShootSide.Up; // side we're shooting the bullet from is the right one
        newBullet.GetComponent<BossBullet>().side = side;
        // shooting 2nd bullet
        newBullet = Instantiate(Bullet, shootPositions[1].position, shootPositions[1].rotation); // spawn bullet 2
        side = ShootSide.Right; // side we're shooting the bullet from is the right one
        newBullet.GetComponent<BossBullet>().side = side;
        // shooting 3rd bullet
        newBullet = Instantiate(Bullet, shootPositions[2].position, shootPositions[2].rotation); // spawn bullet 3
        side = ShootSide.Down; // side we're shooting the bullet from is the down one
        newBullet.GetComponent<BossBullet>().side = side;
        // shooting 2nd bullet
        newBullet = Instantiate(Bullet, shootPositions[3].position, shootPositions[3].rotation); // spawn bullet 4
        side = ShootSide.Left; // side we're shooting the bullet from is the left one
        newBullet.GetComponent<BossBullet>().side = side;
    }
}
