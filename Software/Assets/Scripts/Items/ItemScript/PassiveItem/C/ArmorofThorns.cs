using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorofThorns : PassiveItem
{
    override public void OnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.armor++;
        ps.contactArmor = true;
    }
    override public void UnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.armor--;
        ps.contactArmor = false;
    }
}
