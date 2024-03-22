using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Loot")]
public class Loot : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    public bool stackable;
    public int maxStackSize;


    //Loot Generation Constructor passes item name and drop
    public void lootGenerator(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
