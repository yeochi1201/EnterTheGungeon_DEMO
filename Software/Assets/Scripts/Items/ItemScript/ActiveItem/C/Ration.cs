using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ration : ActiveItem
{
    public override void OnEquip()
    {
        
    }

    public override void UnEquip()
    {
        
    }

    public override void Consume()
    {
        GameObject.Find("Player").GetComponent<PlayerSpecification>().currentHP += 2.0f;
    }
}