using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBoots : PassiveItem
{
    public override void OnEquip()
    {
        GameObject go = GameObject.Find("Player");
        go.GetComponent<PlayerSpecification>().trapArmor = true;
        go.GetComponent<PlayerSpecification>().ignoreKnockback = true;
    }

    public override void UnEquip()
    {
        GameObject go = GameObject.Find("Player");
        go.GetComponent<PlayerSpecification>().trapArmor = false;
        go.GetComponent<PlayerSpecification>().ignoreKnockback = false;
    }
}
