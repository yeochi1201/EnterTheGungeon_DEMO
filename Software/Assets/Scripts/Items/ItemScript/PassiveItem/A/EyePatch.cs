using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePatch : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_degree_buf *= 1.35f;
        ps.weapon_dmg_buf *= 2.00f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<GunBase>().WeaponUpdateDamage(1.35f);
            weapon.GetComponent<GunBase>().WeaponUpdateDegree(2.00f);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_degree_buf /= 0.35f;
        ps.weapon_dmg_buf /= 2.00f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<GunBase>().WeaponRollbackDamage(1.35f);
            weapon.GetComponent<GunBase>().WeaponRollbackDegree(2.00f);
        }
    }
}
