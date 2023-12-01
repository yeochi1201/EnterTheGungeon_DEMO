using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletofPitLord : PassiveItem
{
    public override void OnEquip()
    {
        ItemManager.itemManager.ps.pitArmor = true;
    }

    public override void UnEquip()
    {
        ItemManager.itemManager.ps.pitArmor = false;
    }
}
