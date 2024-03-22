using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerHealth : MonoBehaviour
{
    //self reference to be used anywhere
    public static PlayerHealth instance;

    [SerializeField] public float health = 0f;
    [SerializeField] public float maxHealth = 8f;

    //create action events for player damage and death
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerHealed;
    public static event Action OnPlayerDeath;

    void Awake()
    {
        health = maxHealth;
        instance = this;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        OnPlayerDamaged?.Invoke();

        if(health <= 0f)
        {
            Death();
        }
    }

    public void heal(float hp)
    {
        health += hp;
        OnPlayerHealed?.Invoke();

        //If the player is fully healed, doesn't heal anymore
        if(health >= maxHealth)
        {
            health += 0;
        }
    }

    public void Death()
    {
        //switch to game over scene
        SceneManager.LoadScene("GameOver");
        OnPlayerDeath?.Invoke();

        //player gets destroyed
        Destroy(gameObject);
    }

}
