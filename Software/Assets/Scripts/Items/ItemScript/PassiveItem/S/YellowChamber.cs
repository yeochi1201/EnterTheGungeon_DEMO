using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowChamber : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.maxHP += 2.0f;
        ps.weapon_delay_buf *= 1.15f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<GunBase>().WeaponUpdateDelay(1.15f);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.maxHP -= 2.0f;
        ps.weapon_delay_buf /= 1.15f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<GunBase>().WeaponRollbackDelay(1.15f);
        }
    }
}
