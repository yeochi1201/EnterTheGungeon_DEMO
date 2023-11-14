using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecification : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public float speed;
    public float dmg;
    public int armor;
    public int coolness;
    public int key;
    public int gold;

    public bool superArmor = false;
    public bool trapArmor = false;
    public bool contactArmor = false;
    public bool pitArmor = false;
    public bool ignoreKnockback = false;
    public bool invisible = false;

    public float ammo_degree_buf = 1.0f;
    public float ammo_size_buf = 1.0f;
    public float weapon_dmg_buf = 1.0f;
}
