using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemAsset : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    public enum ItemType 
    {
        Weapon,
        Passive,
        Consume
    }
    public ItemType itemType;
}
