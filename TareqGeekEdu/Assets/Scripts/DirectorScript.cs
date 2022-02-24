using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DirectorScript : MonoBehaviour
{
    public PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    void Update()
    {
        if (director.state != PlayState.Playing) // when the timeline is done playing
        {
            SceneManager.LoadScene("SampleScene"); // load our next scene
        }
    }
}
