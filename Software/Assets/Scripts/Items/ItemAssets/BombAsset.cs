using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemObject/BombItem")]
public class BombAsset : ItemAsset
{
    [SerializeField]
    public int damage;
    public int reloadDamage;
    public int maxOwn;
}