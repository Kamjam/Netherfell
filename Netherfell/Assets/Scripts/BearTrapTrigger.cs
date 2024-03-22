using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapTrigger : MonoBehaviour
{
    private Animator anim;
    public AudioSource audio;
    public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    //If player enters the trap bounding box, trigger the trap
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag  == "Player" && !isTriggered)
        {
            //Play sound and animation
            audio.Play(0);
            anim.SetBool("trigger", true); 

            //trap has been triggered, disable trap collision
            isTriggered = true;

            //Deal the player damage
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(1);

            //Backlog: destroying the trap messes up the player hit animation
        }
        else
        {
            isTriggered = false;
            anim.SetBool("trigger", false); 
        } 
    }
}
