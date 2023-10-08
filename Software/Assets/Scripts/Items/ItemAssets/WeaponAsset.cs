using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemObject/Weapon")]
public class WeaponAsset : ItemAsset
{
    [SerializeField]
    public int ammo_size; //źâ
    public int ammo_count; //ź�˼�
    public float reload; //reload time
    public int ammo_speed;
    public int knock_back;
    public float damage; //weapon damage
    public float delay; //delay at fire
    public int range;
    public int ammo_degree;

    public int current_ammo;
    public int current_ammo_count;

    public enum weapontype 
    { 
        half_auto,
        auto,
        charge,
        beam,
        spread
    }
    public weapontype type;
}
