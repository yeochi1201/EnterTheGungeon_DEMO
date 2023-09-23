using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemObject/Weapon")]
public class WeaponAsset : ItemAsset
{
    [SerializeField]
    public float reload; //reload time
    public float delay; //delay at fire
    public int max_bullet; //fire bullet number before reload/
    public int damage; //weapon damage
}
