using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void PlayGame() // the function we will call to switch to the play scene
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame() // this button to close the game
    {
        Application.Quit();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }

}
