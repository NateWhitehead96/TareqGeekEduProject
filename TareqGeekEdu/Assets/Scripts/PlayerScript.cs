using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentTool
{
    NoTool,
    Axe,
    Pickaxe,
    Sword,
    Hammer
}

public class PlayerScript : MonoBehaviour
{
    // variables
    [SerializeField]
    private float moveSpeed;

    public Rigidbody2D rb2d;

    public Vector2 movement;
    public Vector2 mousePosition;

    // animation stuff
    public Animator animator;
    public bool walking;
    public bool attacking;

    // For our attacking/interacting
    public LayerMask InteractingMask; // the layer we want to interact with
    public Transform AttackPosition; // our hand position

    // Tool variables
    public GameObject[] AllTools;
    public CurrentTool tool;
    public GameObject SwordIcon; // the sword image on our tool belt
    // gameobject of the sword itself
    public bool ownSword; // a bool that tells us if we own the sword or not
    public int swordLevel; // upgrade levels for each tool
    public int axeLevel;
    public int pickaxeLevel;
    public int hammerLevel;
    public GameObject Swordig;
    public Sprite GemSword;
    // PauseControl
    public GameObject PauseCanvas;

    public int Health;
    // Hammer time stuff
    public GameObject Wall;
    public bool ownHammer; // if we own the hammer or not
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        Time.timeScale = 1; // make sure we're not paused
        PauseCanvas.SetActive(false);
        for (int i = 0; i < AllTools.Length; i++)
        {
            AllTools[i].SetActive(false); // to make sure our tools are inactive to start
        }
        tool = CurrentTool.NoTool;
        SwordIcon.SetActive(false); // start the game with the sword icon not active
    }

    // Update is called once per frame
    void Update()
    {
        // Pause control
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) // the numberpad enter button
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        // ------------ movement animation and input ------------------ //
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            walking = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            walking = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            walking = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            walking = false;
        }

        animator.SetBool("IsWalking", walking);

        // --------------- Attacking and attack animation -------------- //

        if (Input.GetMouseButtonDown(0)) // left click
        {
            attacking = true;
            Collider2D[] interactableObjects = Physics2D.OverlapCircleAll(AttackPosition.position, 1, InteractingMask);
            for (int i = 0; i < interactableObjects.Length; i++)
            {
                if (interactableObjects[i].gameObject.CompareTag("Tree") && tool == CurrentTool.Axe)
                {
                    print("Chopped a tree");
                    interactableObjects[i].gameObject.GetComponent<TreeScript>().Health--;
                    PlayerInventory.Logs++; // gainging so logs
                    FindObjectOfType<PlayerInventory>().wood.quantity = PlayerInventory.Logs; // this is very bad
                }
                else if (interactableObjects[i].gameObject.CompareTag("Rock") && tool == CurrentTool.Pickaxe)
                {
                    print("Mined a rock");
                    interactableObjects[i].gameObject.GetComponent<RockScript>().Health--;
                    PlayerInventory.Stones++; // gaining some stones/rocks
                    FindObjectOfType<PlayerInventory>().rock.quantity = PlayerInventory.Stones; // this is very bad
                }
                else if (interactableObjects[i].gameObject.CompareTag("Enemy") && tool == CurrentTool.Sword)
                {
                    print("Killing enemy");
                    interactableObjects[i].gameObject.GetComponent<EnemyScript>().StunEnemy(); // stun the enemy
                    interactableObjects[i].gameObject.GetComponent<EnemyScript>().Health--;
                }
                
            }
            if (tool == CurrentTool.Hammer && PlayerInventory.Logs >= 1) // if we have the hammer out
            {
                PlayerInventory.Logs--; // subtract the cost
                Instantiate(Wall, transform.position + transform.up * 5, Quaternion.identity); // build the wall
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            attacking = false;
        }

        animator.SetBool("isAttacking", attacking); // set our animation to the attacking bool

        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.deltaTime);
        Vector2 lookDirection = mousePosition - rb2d.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;

        SwitchTool();

    }

    void SwitchTool()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // restarts us back to no tools and hide the other tools
        {
            for (int i = 0; i < AllTools.Length; i++)
            {
                AllTools[i].SetActive(false); 
            }
            tool = CurrentTool.NoTool;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // show our axe
        {
            EquipAxe();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // show our pickaxe
        {
            EquipPickaxe();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && ownSword == true) // if we own the sword we can equip it
        {
            EquipSword();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && ownHammer == true) // if we own hammer we can equip it
        {
            EquipHammer();
        }
    }

    // Toolbox button functions
    public void EquipAxe() // does the same of our switch tool to axe
    {
        for (int i = 0; i < AllTools.Length; i++)
        {
            AllTools[i].SetActive(false);
        }
        AllTools[0].SetActive(true);
        tool = CurrentTool.Axe;
    }

    public void EquipPickaxe()
    {
        for (int i = 0; i < AllTools.Length; i++)
        {
            AllTools[i].SetActive(false);
        }
        AllTools[1].SetActive(true);
        tool = CurrentTool.Pickaxe;
    }

    public void EquipSword()
    {
        for (int i = 0; i < AllTools.Length; i++)
        {
            AllTools[i].SetActive(false);
        }
        AllTools[2].SetActive(true);
        tool = CurrentTool.Sword;
    }

    public void EquipHammer()
    {
        for (int i = 0; i < AllTools.Length; i++)
        {
            AllTools[i].SetActive(false);
        }
        AllTools[3].SetActive(true);
        tool = CurrentTool.Hammer;
    }
}
