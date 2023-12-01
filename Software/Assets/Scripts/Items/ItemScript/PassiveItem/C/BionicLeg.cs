using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BionicLeg : PassiveItem
{
    override public void OnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.speed += 2.0f;
        ps.armor++;
    }
    override public void UnEquip()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.armor--;
        ps.speed -= 2.0f;
    }
}
