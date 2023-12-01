using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedBullets : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps; ;
        ps.cursed += 1;
        for(int i=0;i<ps.cursed;i++)
        {
            ps.weapon_dmg_buf *= 1.1f;
        }
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons)
        {
            for (int i = 0; i < ps.cursed; i++)
            {
                weapon.GetComponent<WeaponItem>().WeaponUpdateDamage(ps.weapon_dmg_buf);
            }
        }
        ItemManager.itemManager.Cursed_Changed(1);
        ItemManager.itemManager.SetExist(0, true);
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps; ;
        ps.cursed -= 1;
        for (int i = 0; i < ps.cursed; i++)
        {
            ps.weapon_dmg_buf /= 1.1f;
        }
        Inven inven = ItemManager.itemManager.inven;
        foreach (GameObject weapon in inven.weapons)
        {
            for (int i = 0; i < ps.cursed; i++)
            {
                weapon.GetComponent<WeaponItem>().WeaponUpdateDamage(ps.weapon_dmg_buf);
            }
        }
        ItemManager.itemManager.Cursed_Changed(-1);
        ItemManager.itemManager.SetExist(0, false);
    }
}
