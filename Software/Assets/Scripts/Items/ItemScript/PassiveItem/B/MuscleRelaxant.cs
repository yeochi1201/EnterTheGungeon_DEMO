using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleRelaxant : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.ammo_degree_buf /= 1.60f;
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<WeaponItem>().WeaponUpdateDegree(ps.ammo_degree_buf);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.ammo_degree_buf *= 1.60f;
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<WeaponItem>().WeaponUpdateDegree(ps.ammo_degree_buf);
        }
    }
}
