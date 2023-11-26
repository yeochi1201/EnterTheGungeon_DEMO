using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedBullets : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.cursed += 1;
        for(int i=0;i<ps.cursed;i++)
        {
            ps.weapon_dmg_buf *= 1.1f;
        }
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            for (int i = 0; i < ps.cursed; i++)
            {
                weapon.GetComponent<GunBase>().WeaponUpdateDamage(1.1f);
            }
        }
        ItemManager.itemManager.Cursed_Changed(1);
        ItemManager.itemManager.SetExist(0, true);
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.cursed -= 1;
        for (int i = 0; i < ps.cursed; i++)
        {
            ps.weapon_dmg_buf /= 1.1f;
        }
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            for (int i = 0; i < ps.cursed; i++)
            {
                weapon.GetComponent<GunBase>().WeaponRollbackDamage(1.1f);
            }
        }
        ItemManager.itemManager.Cursed_Changed(-1);
        ItemManager.itemManager.SetExist(0, false);
    }
}
