using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBoots : PassiveItem
{
    public override void OnEquip()
    {
        ItemManager.itemManager.ps.trapArmor = true;
        ItemManager.itemManager.ps.ignoreKnockback = true;
    }

    public override void UnEquip()
    {
        ItemManager.itemManager.ps.trapArmor = false;
        ItemManager.itemManager.ps.ignoreKnockback = false;
    }
}
