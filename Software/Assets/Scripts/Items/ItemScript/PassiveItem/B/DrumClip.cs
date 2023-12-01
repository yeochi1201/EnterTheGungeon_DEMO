using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumClip : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.ammo_count_buf *= 1.5f;

        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponUpdateAmmoCount(ps.ammo_count_buf);
        }
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.ammo_count_buf /= 1.5f;

        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponUpdateAmmoCount(ps.ammo_count_buf);
        }
        
    }
}
