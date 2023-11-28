using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable : MonoBehaviour
{
    public GameObject prefab;
    public GameObject chest;
    [SerializeField]
    DTAsset droptable;

    public void Drop()
    {
        GameObject item = ChoiceItem();
        Instantiate<GameObject>(prefab, null, chest.transform);
    }

    public GameObject ChoiceItem() //choice item randomly in droptable
    {
        GameObject result;
        int key = Random.Range(1, droptable.droplist.Count);

        result = droptable.droplist[key];
        return result;
    }

}
