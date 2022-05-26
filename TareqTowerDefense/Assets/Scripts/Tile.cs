using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied; // to know if the tile has a tower on it or not

    public Color hasTower;
    public Color noTower;
    // Start is called before the first frame update
    void Start()
    {
        hasTower = Color.green; // when the tower is placed, the tile will be green
        noTower = Color.black; // when there is no tower
    }

    // Update is called once per frame
    void Update()
    {
        if(isOccupied == true)
        {
            GetComponent<SpriteRenderer>().color = hasTower; // make the tile this color when it has a tower
        }
        if(isOccupied == false)
        {
            GetComponent<SpriteRenderer>().color = noTower; // make the tile this color when it has no tower
        }
    }
}
