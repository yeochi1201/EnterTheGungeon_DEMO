using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartofIce : PassiveItem
{
    override public void OnEquip()
    {
        PlayerSpecification PS = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        PS.coolness++;
        PS.maxHP++;
    }
    override public void UnEquip()
    {
        PlayerSpecification PS = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        PS.coolness--;
        PS.maxHP--;
    }
}
