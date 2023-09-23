using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAsset : ScriptableObject
{
    [SerializeField]
    public string itemName; //item's name
    public Sprite sprite; //item sprite
    public char Rank; //item rank
}