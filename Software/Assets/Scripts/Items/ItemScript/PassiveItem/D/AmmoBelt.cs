using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBelt : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_size_buf *= 1.20f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<WeaponItem>().WeaponUpdateAmmoSize(1.20f);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_size_buf /= 1.20f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<WeaponItem>().WeaponRollbackAmmoSize(1.20f);
        }
    }

}
