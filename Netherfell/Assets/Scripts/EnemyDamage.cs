using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDamage : MonoBehaviour
{
    public SkeletonController skeleton;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //deals damage to player
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(1);
        }
    }

    //if the player stays too long on the damage collider, prevent infinite damage
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //prevent infinite damage spamming 
            if(skeleton.atkSpd <= skeleton.canAttack)
            {
                //deals damage to player
                collision.gameObject.GetComponent<PlayerHealth>().takeDamage(1);
                //reset timer
                skeleton.canAttack = 0f;
            }
            else
            {
                skeleton.canAttack += Time.deltaTime;
            }
        }
    }
}
