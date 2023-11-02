using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemObject/BombItem")]
public class BombAsset : ItemAsset
{
    [SerializeField]
    public int damage; //bomb damage
    public int rechargeDamage; //needed damage to reload bomb
    public int splashRange; //maximum carry bomb
    public int range;
}