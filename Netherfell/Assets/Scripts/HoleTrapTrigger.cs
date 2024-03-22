using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleTrapTrigger : MonoBehaviour
{
    //Reset the level when the player falls into the hole
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name  == "Player")
        {
            //check the current scene name and resets the appropriate floor
            //Backlog: dealing one heart damage that doesn't reset when the level reloads or the scene changes to the next level

            //Backlog: trigger a falling animation that just scales the player down to simulate falling
            new WaitForSeconds(1);
            SceneManager.LoadScene("GameOver");
        }
    }
}
