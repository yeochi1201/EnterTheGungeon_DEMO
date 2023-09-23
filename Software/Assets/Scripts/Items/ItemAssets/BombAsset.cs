using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemObject/BombItem")]
public class BombAsset : ItemAsset
{
    [SerializeField]
    public int damage; //bomb damage
    public int reloadDamage; //needed damage to reload bomb
    public int maxOwn; //maximum carry bomb
}