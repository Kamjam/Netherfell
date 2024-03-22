using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCollection : MonoBehaviour
{
    //reference to the sprite images
    public Sprite gold, potion, apple;
    
    //reference to gold counting script
    private GoldCounter goldCounter;

    //reference to the item counting script
    private ItemCounter itemCounter;

    void Start()
    {
        goldCounter = GoldCounter.instance;
        itemCounter = ItemCounter.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag  == "Player")
        {
            Destroy(gameObject);

            //check if the picked up loot has the gold piece sprite, if it does increment the gold counter
            if(GetComponent<SpriteRenderer>().sprite == gold)
            {
                goldCounter.increaseCurrency(1);
            }
            else if(GetComponent<SpriteRenderer>().sprite == potion)
            {
                itemCounter.increaseLeftSlot(1);
            }
            else if(GetComponent<SpriteRenderer>().sprite == apple)
            {
                itemCounter.increaseRightSlot(1);
            }
        }
    }
}
