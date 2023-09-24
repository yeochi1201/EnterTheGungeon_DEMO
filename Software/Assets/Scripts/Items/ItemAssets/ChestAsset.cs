using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemObject/Chest")]
public class ChestAsset : ItemAsset
{
    [SerializeField]
    public enum ChestType //drop item type
    {
        Item, //potion, passive, bomb
        Weapon
    }
    public Rank rank;
    public ChestType type;
    public bool key = false;
}
