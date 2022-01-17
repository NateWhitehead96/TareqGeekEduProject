using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Text RandomText;

    public string[] RandomSentences;
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, RandomSentences.Length); // find a random sentence from our array of sentences
        RandomText.text = RandomSentences[x]; // the random text will be one of our sentences
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene"); // when we hit the play button, move to the play scene
    }
}
