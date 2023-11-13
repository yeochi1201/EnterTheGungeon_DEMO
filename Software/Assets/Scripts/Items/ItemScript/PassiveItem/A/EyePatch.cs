using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePatch : PassiveItem
{
    public override void OnEquip()
    {
        // Weapon Dmg +35%
        // Armor degree +100%
    }

    public override void UnEquip()
    {
        // Weapon Dmg -35%
        // Armor degree -100%
    }
}
