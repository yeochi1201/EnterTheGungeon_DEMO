using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "ItemObject/PotionItem")]
public class PotionAsset : ItemAsset
{
    [SerializeField]
    public int heal;
    public int addDmg;
    public int addCoolness;
    public int increaseHP;
    public float cooltime;
    public int limitUSE;
}
