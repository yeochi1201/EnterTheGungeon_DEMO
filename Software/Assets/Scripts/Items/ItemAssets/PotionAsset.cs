using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "ItemObject/PotionItem")]
public class PotionAsset : ItemAsset
{
    [SerializeField]
    public int heal; //heal value
    public int addDmg; //buf for damage
    public int addCoolness; //buf for coolness
    public int increaseHP; //buf for max hp
    public float cooltime; //item's cooltime
    public int limitUSE; //maximum using
}
