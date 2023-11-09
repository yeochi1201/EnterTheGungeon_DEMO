using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cigarrettes : ActiveItem
{
    override public void OnEquip()
    {

    }
    override public void UnEquip()
    {

    }
    override public void Consume()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.currentHP--;
        ps.coolness++;
    }
}
