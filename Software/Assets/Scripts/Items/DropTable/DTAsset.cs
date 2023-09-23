using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DropTable/DT")]
public class DTAsset : ScriptableObject
{
    [SerializeField]
    public ItemAsset[] ItemList; //droptable's item
}
