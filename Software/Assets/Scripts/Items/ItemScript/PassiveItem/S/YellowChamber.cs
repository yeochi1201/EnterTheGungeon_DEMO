using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowChamber : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.maxHP += 2;
        ps.weapon_delay_buf *= 1.15f;
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponUpdateDelay(ps.weapon_delay_buf);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps; ;
        ps.maxHP -= 2.0f;
        ps.weapon_delay_buf /= 1.15f;
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponUpdateDelay(ps.weapon_delay_buf);
        }
    }
}
