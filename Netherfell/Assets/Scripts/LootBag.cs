using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();

    //simple function to drop items
    //return values get sent to the lootGeneration function in Loot script
    Loot GetDroppedItem()
    {
        //drop chance range
        int randomNum = Random.Range(1,101); 

        //new list of items
        List<Loot> possibleItems = new List<Loot>();
        foreach(Loot item in lootList)
        {
            //if the rand num falls within the drop chance add to the new list
            if(randomNum <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }

         //checking if things were added to the list
        if(possibleItems.Count > 0)
        {
            //pick random loot within the possible item pool
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }

        //No loot dropped
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    { 
        Loot droppedItem = GetDroppedItem();
        //If there is loot dropped
        if(droppedItem != null)
        {
            //Spawn loot
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            
            //Apply the correct sprite to the newly spawned item
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

            //Add force so the items slide into a random direction when they spawn
            float dropForce = 30f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }
}
