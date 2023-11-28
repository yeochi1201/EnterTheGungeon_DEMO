using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DropTable/Droptable")]
public class DTAsset : ScriptableObject
{
    [SerializeField]
    public List<GameObject> droplist = new List<GameObject> ();
}
