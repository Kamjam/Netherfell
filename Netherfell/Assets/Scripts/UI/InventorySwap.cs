using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwap : MonoBehaviour
{
    public GameObject swordSlot;
    public GameObject slotSprite;
    public static InventorySwap instance;

    void Awake()
    {
        instance = this;
        //slotSprite = swordSlot.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }

    //swap is supposed to take in a sprite and replace the current one
    public void swapSlot(Sprite newSprite)
    {
        slotSprite.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}