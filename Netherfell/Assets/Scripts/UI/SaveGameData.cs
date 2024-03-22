using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    //reference to these files
    private GoldCounter goldCounter;
    private PlayerHealth playerHealth;

    //data to be saved
    public int health;
    public int gold;

    void Start()
    {
        //set instancese
        goldCounter = GoldCounter.instance;
        playerHealth = PlayerHealth.instance;
    }
    
    void Update()
    {
        //set the variables
        health = (int)playerHealth.health;
        gold = (int)goldCounter.currentCount;
    }
}
