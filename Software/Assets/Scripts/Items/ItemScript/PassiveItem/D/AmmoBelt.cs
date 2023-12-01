using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBelt : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.ammo_size_buf *= 1.20f;
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<WeaponItem>().WeaponUpdateAmmoSize(ps.ammo_size_buf);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.ammo_size_buf /= 1.20f;
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<WeaponItem>().WeaponUpdateAmmoSize(ps.ammo_size_buf);
        }
    }

}
