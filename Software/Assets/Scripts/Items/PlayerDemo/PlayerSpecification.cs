using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecification : MonoBehaviour
{
    public float maxHP = 6.0f;
    public float currentHP = 6.0f;
    public float speed = 5.0f;
    public float dmg = 0;
    public int armor = 0;
    public int coolness = 0;
    public int key = 0;
    public int gold = 0;
    public int currentBlank = 2;
    public int cursed = 0;

    public bool superArmor = false;
    public bool trapArmor = false;
    public bool contactArmor = false;
    public bool pitArmor = false;
    public bool ignoreKnockback = false;
    public bool invisible = false;

    public float ammo_degree_buf = 1.0f;
    public float ammo_size_buf = 1.0f;
    public float weapon_dmg_buf = 1.0f;
    public float weapon_reload_buf = 1.0f;
    public float weapon_delay_buf = 1.0f;
    public float ammo_count_buf = 1.0f;
}
