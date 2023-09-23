using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemObject/Chest")]
public class ChestAsset : ScriptableObject
{
    [SerializeField]
    public enum Rank
    { 
        D,
        C,
        B,
        A,
        S
    }
    public enum ChestType 
    {
        Item,
        Weapon
    }
    public Rank rank;
    public ChestType type;
    public bool key = false;
}
