using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BionicLeg : PassiveItem
{
    override public void OnEquip()
    {
        PlayerSpecification PS = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        PS.speed += 2.0f;
        PS.armor++;
    }
    override public void UnEquip()
    {
        PlayerSpecification PS = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        PS.armor--;
        PS.speed -= 2.0f;
    }
}
