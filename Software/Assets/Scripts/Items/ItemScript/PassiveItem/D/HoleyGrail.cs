using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleyGrail : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.cursed++;
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.cursed--;
    }
}
