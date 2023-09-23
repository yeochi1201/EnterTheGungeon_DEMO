using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAsset : ScriptableObject
{
    [SerializeField]
    public string itemName;
    public Sprite sprite;
    public char Rank;
    public int coolness;
}