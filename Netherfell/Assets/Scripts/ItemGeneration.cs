using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGeneration : MonoBehaviour
{
    //sets an array of sprites
    public Sprite[] swords  = new Sprite[5];

    private void Start()
    {
        drawItem();
    }

    public void drawItem()
    {
        //random number to be the indesx for the array and set the correct sprite
        int randomNum = Random.Range(0,5); 
        
        switch(randomNum)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = swords[0];
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = swords[1];
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = swords[2];
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = swords[3];
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = swords[4];
                break;
        }
    }
}
