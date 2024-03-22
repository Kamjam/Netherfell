using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    //reference to the gold sprite
    public Sprite sword1, sword2, sword3, sword4, sword5;
    private InventoryPanel inventoryPanel;
    private InventorySwap inventorySwap;

    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel = InventoryPanel.instance;
        inventorySwap = InventorySwap.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag  == "Player")
        {
            //compare the item sprite with the ones stored here
            //swap the corresponding sprite to update inventory
            //then destroy the object
            if(GetComponent<SpriteRenderer>().sprite == sword1)
            {
                inventorySwap.swapSlot(sword1);
                Destroy(gameObject);
            }
            else if(GetComponent<SpriteRenderer>().sprite == sword2)
            {
                inventorySwap.swapSlot(sword2);
                Destroy(gameObject);
            }
            else if(GetComponent<SpriteRenderer>().sprite == sword3)
            {
                inventorySwap.swapSlot(sword3);
                Destroy(gameObject);
            }
            else if(GetComponent<SpriteRenderer>().sprite == sword4)
            {
                inventorySwap.swapSlot(sword4);
                Destroy(gameObject);
            }
            else if(GetComponent<SpriteRenderer>().sprite == sword5)
            {
                inventorySwap.swapSlot(sword5);
                Destroy(gameObject);
            }                          
        }
    }
}
