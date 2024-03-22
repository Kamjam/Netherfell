using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Play button is clicked
    public void StartGameButton()
    {
        SceneManager.LoadScene("BasementOne");
    }
    
    //Retry Button is clicked after Game Over
    public void RetryGameButton()
    {
        SceneManager.LoadScene("BasementOne");
    }

    // Exit button is clicked
    public void ExitGameButton()
    {
        Application.Quit();
    }
}
