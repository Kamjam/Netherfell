using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeartBarManager : MonoBehaviour
{
    public GameObject heartPrefab;

    //reference player health from the player health script
    public PlayerHealth playerHealth;

    //list of all the health statuses taken from the Heart Changer script
    List<HeartChanger> hearts = new List<HeartChanger>();

    //enable player events
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDamaged += drawHearts;
        PlayerHealth.OnPlayerHealed += drawHearts;
    }

    //disable player events
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDamaged -= drawHearts;
        PlayerHealth.OnPlayerHealed -= drawHearts;
    }

    private void Start()
    {
        drawHearts();
    }

    //draw all the hearts in the bar
    public void drawHearts()
    {
        //clear the health bar
        clearHearts();

        //determine how many hearts to make in total, which is based on max health
        float maxHealthRemainder = playerHealth.maxHealth % 2; //Just checks of the maxhealth is odd or even; odd should return 1
        
        //if max health is 8, make 4 hearts; max health is 3, make 2 hearts
        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);

        //create an empty heart for every heart you need make to fill the bar with the calculated amount needed
        for(int i = 0; i < heartsToMake; i++)
        {
            createEmptyHeart();
        }

        //Go through each new empty heart that was just created and 
        //change the sprite and status to reflect the current health
        for(int i = 0; i < hearts.Count; i++)
        {
            //determine heart status for each new heart at the current health
            //min and max for the clamp is determined by how many enum values we have
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - (i*2), 0, 2);
            
            //set the correct sprite image, cast as a heart status enum
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }

    //create an empty heart
    public void createEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);

        //makes sure the new heart is a child of the heart bar
        newHeart.transform.SetParent(transform);

        //set the component to empty so that the prefab is empty
        HeartChanger heartComponent = newHeart.GetComponent<HeartChanger>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        
        //add to the list so that it can be tracked
        hearts.Add(heartComponent);
    }

    //resets the heart bar
    public void clearHearts()
    {
        //clear all the heart objects as a the child of healthbar
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        //create a brand new list of hearts
        hearts = new List<HeartChanger>();
    }
}
