using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthChamber : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.cursed += 2;
        ps.coolness += ps.cursed * 2;
        ItemManager.itemManager.Cursed_Changed(2);
        ItemManager.itemManager.SetExist(0, true);
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.cursed -= 2;
        ps.coolness -= ps.cursed * 2;
        ItemManager.itemManager.Cursed_Changed(-2);
        ItemManager.itemManager.SetExist(0, false);
    }
}
