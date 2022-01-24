using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeScript : MonoBehaviour
{
    public int Health = 3;
    public Slider HitSlider; // the slider
    public GameObject HitCanavs; // this the canvas
    public Sprite[] sprites; // this would hold the different health versions of this resource

    private void Start()
    {
        HitSlider.maxValue = Health;
        HitSlider.value = Health;
        HitCanavs.SetActive(false);
    }

    private void Update()
    {
        HitSlider.value = Health;
        if (Health < 3)
        {
            HitCanavs.SetActive(true);
        }
        if(Health <= 0) // we might change this to just being inactive to reactive every day
        {
            gameObject.SetActive(false);
        }
    }
}
