using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController2D : MonoBehaviour
{
    //player movement variables
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    //player animation variables
    public Animator anim;
    public SpriteRenderer sprite;

    //player sound
    public AudioSource audio;

    //variable for direction sprite is facing
    bool facingRight = false;
    bool facingBack = false;

    //player stats and traits
    public float atkDmg = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("moveX", moveDirection.x);
        anim.SetFloat("moveY", moveDirection.y);
        anim.SetFloat("speed", moveDirection.sqrMagnitude);

        //make sure to flip character when appropriate
        checkDirection();

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1|| 
            Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("lastX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("lastY", Input.GetAxisRaw("Vertical"));
        }
    }

    //Simple 2D movement
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);

        checkDirection();
    }

    //Trap collision logic
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //trap collision
        if(collision.gameObject.tag  == "Trap")
        {
            anim.SetBool("hit", true); 
        }

        //enemy collision and damage
        if(collision.gameObject.tag == "Enemy")
        {
            //play sound
            audio.Play(0);
            
            anim.SetBool("hit", true); 

            //Backlog: dealing damage is broken on the enemy script
            gameObject.GetComponent<PlayerHealth>().takeDamage(1);

            //calls enemy script to make the enemy take damage
            collision.gameObject.GetComponent<SkeletonController>().takeDamage(atkDmg);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag  == "Trap")
        {
            anim.SetBool("hit", false); 
        }

        if(collision.gameObject.tag  == "Enemy")
        {
            anim.SetBool("hit", false); 
        }
    }

    //function to flip the character
    void checkDirection()
    {
        //if we are moving in a positive direction along the x axis
        if(moveDirection.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;  
        }
    }
}
