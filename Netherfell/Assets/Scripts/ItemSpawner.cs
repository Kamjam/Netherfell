using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    
    private void Start()
    {
        //simple way to quickly spawn a prefab
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }
}