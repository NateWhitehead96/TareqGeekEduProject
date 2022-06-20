using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public int gold; // games currancy
    public Building towerToPlace; // the tower we want to place
    public CustomCursor customCursor; // link to our custom cursor
    public Tile[] tiles; // all of our tiles
    public Text goldDisplay;
    // Start is called before the first frame update
    void Start()
    {
        customCursor.gameObject.SetActive(false); // hide the custom cursor to start
    }

    // Update is called once per frame
    void Update()
    {
        PlaceTower();
        goldDisplay.text = "Gold: " + gold;
    }

    public void PlaceTower()
    {
        if(Input.GetMouseButtonDown(0) && towerToPlace != null) // left click and we have a tower to place
        {
            Tile nearestTile = null; // this will be the nearest tile to our left click
            float nearestDistance = float.MaxValue; // this will store the nearest distance of that tile

            foreach (Tile tile in tiles) // loop through all of our tiles in our grid
            {
                // find the distance from our mouse to each tile
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if(distance < nearestDistance) // our mouse is over a tile
                {
                    nearestDistance = distance; // sets the nearest distance to our mouse position
                    nearestTile = tile; // sets nearest tile to the tile closest to our mouse
                }
            }
            if(nearestTile.isOccupied == false) // make sure the tile isnt occupied
            {
                Building newTower = Instantiate(towerToPlace, nearestTile.transform.position, Quaternion.identity);
                newTower.tile = nearestTile; // set the tile of our tower to the nearest tile
                nearestTile.isOccupied = true; // the tower is on the tile
                towerToPlace = null; // reset the tower to place
                Cursor.visible = true; // reshow the defualt cursor
                customCursor.gameObject.SetActive(false); // hide custom cursor
            }
        }
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
