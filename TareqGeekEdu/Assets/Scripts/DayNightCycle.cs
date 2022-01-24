using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    public Light2D GlobalLight; // our sun/global light

    public float ChangeRate; // this will be how fast or slow the sun changes

    public int Direction; // to go towards day or night + or - respectively

    public TreeScript[] WorldTrees; // a list of all the trees in our game
    public RockScript[] WorldRocks; // a list of all the rocks in our game
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GlobalLight.intensity += ChangeRate * Direction * Time.deltaTime; // will decrease or increase our global intensity

        if(GlobalLight.intensity > 1) // we're at our top intensity for the day, PEAK DAYLIGHT NOON
        {
            Direction = -1;
        }

        if(GlobalLight.intensity < 0) // we're at our lowest intensity for the day,  PEAK NIGHT TIME MIDNIGHT
        {
            Direction = 1;
            for (int i = 0; i < WorldTrees.Length; i++)
            {
                WorldTrees[i].gameObject.SetActive(true);
                WorldTrees[i].Health = 3;
            }
            for (int i = 0; i < WorldRocks.Length; i++)
            {
                WorldRocks[i].gameObject.SetActive(true);
                WorldRocks[i].Health = 3;
            }
        }
    }
}
