using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorofThorns : PassiveItem
{
    override public void OnEquip()
    {
        PlayerSpecification PS = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        PS.armor++;
    }
    override public void UnEquip()
    {
        PlayerSpecification PS = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        PS.armor--;
    }
}
