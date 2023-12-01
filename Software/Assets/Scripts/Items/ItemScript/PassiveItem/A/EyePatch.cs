using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePatch : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.ammo_degree_buf *= 1.35f;
        ps.weapon_dmg_buf *= 2.00f;
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<WeaponItem>().WeaponUpdateDamage(ps.ammo_degree_buf);
            weapon.GetComponent<WeaponItem>().WeaponUpdateDegree(ps.weapon_dmg_buf);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.ammo_degree_buf /= 0.35f;
        ps.weapon_dmg_buf /= 2.00f;
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<WeaponItem>().WeaponUpdateDamage(ps.ammo_degree_buf);
            weapon.GetComponent<WeaponItem>().WeaponUpdateDegree(ps.weapon_dmg_buf);
        }
    }
}
