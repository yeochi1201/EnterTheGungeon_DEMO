using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcientHerosBandana : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_size_buf *= 5.00f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponUpdateAmmoSize(5.00f);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_size_buf /= 5.00f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponRollbackAmmoSize(5.00f);
        }
    }
}
