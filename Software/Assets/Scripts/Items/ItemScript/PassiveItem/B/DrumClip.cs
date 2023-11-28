using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumClip : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_count_buf *= 1.5f;
        
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponUpdateAmmoCount(1.5f);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_count_buf /= 1.5f;

        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponRollbackAmmoCount(1.5f);
        }
    }
}
