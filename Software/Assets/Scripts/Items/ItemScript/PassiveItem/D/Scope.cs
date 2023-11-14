using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_degree_buf /= 1.60f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        /*foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<GunBase>().WeaponRollbackDegree(1.60f);
        }*/
        //ÃÑ±â ammo_degree -60%
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.ammo_degree_buf *= 1.60f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        /*foreach (GameObject weapon in inven.weapons){
            weapon.GetComponent<GunBase>().WeaponUpdateDegree(1.60f);
        }*/
    }
}
