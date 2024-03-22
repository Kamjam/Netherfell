using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float speed = 2f;
    private Transform target;

    //enemy attacking variables
    [SerializeField] public float atkDmg = 1f;
    [SerializeField] public float atkSpd = 1f;
    public float canAttack;

    //enemy stats variable
    [SerializeField] public float health = 0f;
    [SerializeField] public float maxHealth = 15f;

    [SerializeField] EnemyHealthBar healthBar;

    void Start()
    {
        //set animator
        anim = GetComponent<Animator>();
        
        //set health
        health = maxHealth;
        healthBar = GetComponentInChildren<EnemyHealthBar>(); 
        //update health
        healthBar.updateHealthBar(health, maxHealth);
    }

    void Update()
    {
        //the enemy will follow the player every frame
        followPlayer();
    }

    //check if player is within the circle collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            target = collision.transform;
        }
    }

    //check if player is not within the circle collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    //function for following the player
    void followPlayer()
    {
        //if the player is a target, follow the player
        if(target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    //enemy taking damage
    public void takeDamage(float damage)
    {
        health -= damage;
        healthBar.updateHealthBar(health, maxHealth);

        if(health <= 0)
        {
            Death();
        }
    }

    //enemy
    void Death()
    {
        //upon death it spawns loot
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }
}
