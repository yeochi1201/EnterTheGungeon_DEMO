using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : ActiveItem
{
    public override void OnEquip()
    {
        
    }

    public override void UnEquip()
    {
        
    }

    public override void Consume()
    {
        ItemManager.itemManager.ps.currentHP += 4.0f;
    }
}