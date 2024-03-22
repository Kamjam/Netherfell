using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ExitStairs : MonoBehaviour
{
    //when the player collides with a exit stair, go to the next level
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //check the current scene name and change to the next one
            if(SceneManager.GetActiveScene().name == "BasementOne")
            {
                SceneManager.LoadScene("FloorOne");
            }
            else if(SceneManager.GetActiveScene().name == "FloorOne")
            {
                SceneManager.LoadScene("FloorTwo");
            }
            else if(SceneManager.GetActiveScene().name == "FloorTwo")
            {
                SceneManager.LoadScene("ArenaOne");
            }
            else if(SceneManager.GetActiveScene().name == "ArenaOne")
            {
                SceneManager.LoadScene("EndGame");
            }
        }
    }
}
