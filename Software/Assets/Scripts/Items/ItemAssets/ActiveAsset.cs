using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "ItemObject/ActiveItem")]
public class ActiveAsset : ItemAsset
{
    [SerializeField]
    public float cooltime; //item's cooltime
    public int limitUSE; //maximum using
    public int[] reuseDmg = new int[5];
    public float nextUseTime;
    public int nextUseDmg;
}
