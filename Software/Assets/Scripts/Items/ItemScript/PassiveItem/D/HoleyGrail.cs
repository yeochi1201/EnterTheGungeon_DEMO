using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleyGrail : PassiveItem
{
    public override void OnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.cursed++;
        
        
    }

    public override void UnEquip()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.cursed--;
    }
}
