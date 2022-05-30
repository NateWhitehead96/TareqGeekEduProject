using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public int gold; // games currancy
    public Building towerToPlace; // the tower we want to place
    public CustomCursor customCursor; // link to our custom cursor
    public Tile[] tiles; // all of our tiles
    // Start is called before the first frame update
    void Start()
    {
        customCursor.gameObject.SetActive(false); // hide the custom cursor to start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyTower(Building tower)
    {
        if(gold >= tower.cost)
        {
            customCursor.gameObject.SetActive(true); // activate the cursor
            customCursor.GetComponent<SpriteRenderer>().sprite = tower.GetComponent<SpriteRenderer>().sprite; // make the cursor be the tower
            Cursor.visible = false; // optional, but hide the main cursor so we can see the custom one better

            gold -= tower.cost; // subtract the cost from currancy
            towerToPlace = tower; // set the tower we want to place to be this tower
        }
    }
}
