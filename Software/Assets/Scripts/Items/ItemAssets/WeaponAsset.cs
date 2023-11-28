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

    public int current_ammo_size;
    public int current_ammo_count;
    public int current_degree;

    public enum weapontype 
    { 
        half_auto,
        auto,
        charge,
        beam,
        spread
    }
    public weapontype type;

    public enum projectiletype
    {
        VELOCITY,
        HELIX,
        HOMING,
        COLOR,
        TRAIL,
        RAY,
        SPLIT,
        MAX_SIZE
    }
    public projectiletype proejectile;

    private void Awake()
    {
        current_ammo_size = ammo_size;
        current_ammo_count = ammo_count-ammo_size;
        current_degree = ammo_degree;
    }
}
