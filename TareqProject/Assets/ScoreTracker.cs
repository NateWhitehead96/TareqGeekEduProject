using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    public Text ScoreText; // the text used for displaying score
    public Text HealthText;
    public PlayerScript player; // a reference to our player so we can access score

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + player.score; // update the text to show our player score
        HealthText.text = "Health: " + player.health; // update our health
    }
}
