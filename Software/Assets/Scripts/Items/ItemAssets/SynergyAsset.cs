using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyAsset : ScriptableObject
{
    [SerializeField]
    public ItemAsset mainitem;
    public ItemAsset subitem;

    virtual public void SynergyOn()
    {
        //synergy effect
    }

}
