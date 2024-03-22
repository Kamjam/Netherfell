using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UseItemButton : MonoBehaviour
{
    //reference to the counting scripts
    private GoldCounter goldCounter;
    private ItemCounter itemCounter;

    //reference to player health script
    private PlayerHealth player;

    void Start()
    {
        goldCounter = GoldCounter.instance;
        itemCounter = ItemCounter.instance;
        player = PlayerHealth.instance;
    }
    
    //when player clicks on the object decrease item, and add health to player
    public void leftItem()
    {
        itemCounter.decreaseLeftSlot(1);

        //potion heals full heart
        player.heal(2);
        
        //makes sure that the player health doesn't go over max health
        if(player.health >= player.maxHealth)
        {
            player.health = player.maxHealth;
        }
    }

    //same function but for the right button
    public void rightItem()
    {
        itemCounter.decreaseRightSlot(1);
        
        //apple heals half heart
        player.heal(1);

        //makes sure that the player health doesn't go over max health
        if(player.health >= player.maxHealth)
        {
            player.health = player.maxHealth;
        }
    }
}
