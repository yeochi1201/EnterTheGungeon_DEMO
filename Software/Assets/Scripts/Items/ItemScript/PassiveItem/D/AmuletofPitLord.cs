using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletofPitLord : PassiveItem
{
    public override void OnEquip()
    {
        GameObject.Find("Player").GetComponent<PlayerSpecification>().pitArmor = true;
    }

    public override void UnEquip()
    {
        GameObject.Find("Player").GetComponent<PlayerSpecification>().pitArmor = false;
    }
}
