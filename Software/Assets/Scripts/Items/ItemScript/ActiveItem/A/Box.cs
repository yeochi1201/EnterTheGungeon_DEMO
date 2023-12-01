using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Box : ActiveItem
{
    public override void OnEquip()
    {
        
    }

    public override void UnEquip()
    {
        
    }

    public override void Consume()
    {
        PlayerSpecification ps = ItemManager.itemManager.ps;
        ps.invisible = true;
        float cur = ps.currentHP;
        while (true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                ps.invisible = false;
                break;
            }
        }
    }
}
