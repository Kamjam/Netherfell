using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{

    public GameObject pickupPanel;

    public static InventoryPanel instance;

    //Make sure panel doesn't show when the game starts
    void Awake()
    {
        pickupPanel.SetActive(false);
        instance = this;
    }
    
    //activates panel
    public void panelActivation()
    {
        if(!pickupPanel.activeSelf)
        {
            pickupPanel.SetActive(true);
        }
    }

    //deactivates panel
    public void panelOff()
    {
        if(pickupPanel.activeSelf)
        {
            pickupPanel.SetActive(false);
        }
    }
}
