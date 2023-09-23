using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemObject/Weapon")]
public class WeaponAsset : ItemAsset
{
    [SerializeField]
    public float reload;
    public float delay;
    public int bulletNum;
    public int max_bullet;
    public int damage;
}
