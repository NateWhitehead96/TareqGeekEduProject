using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockScript : MonoBehaviour
{
    [SerializeField]
    public int Health = 3;
    [SerializeField]
    public Slider HitSlider; // the slider
    [SerializeField]
    public GameObject HitCanavs; // this the canvas

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
        if (Health <= 0) // we might change this to just being inactive to reactive every day
        {
            gameObject.SetActive(false);
        }
    }
}
