using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleRelaxant : PassiveItem
{
    public override void OnEquip()
    {
        //armor degree -= 60%
    }

    public override void UnEquip()
    {
        //armor degree += 60%
    }
}
