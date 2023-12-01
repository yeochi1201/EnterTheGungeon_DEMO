using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPurse : PassiveItem
{
    override public void OnEquip()
    {
        PlayerSpecification PS = ItemManager.itemManager.ps;
        PS.maxHP++;
    }
    override public void UnEquip()
    {
        PlayerSpecification PS = ItemManager.itemManager.ps;
        PS.maxHP--;
    }
}
