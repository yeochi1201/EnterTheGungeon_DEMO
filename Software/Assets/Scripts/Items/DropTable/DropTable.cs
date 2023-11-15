using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class DropTable : MonoBehaviour
{
    public GameObject prefab;
    public GameObject chest;
    [SerializeField]
    DTAsset droptable;

    public void Drop()
    {
        string item = ChoiceItem();
        Instantiate<GameObject>(prefab, null, chest.transform);
    }

    public string ChoiceItem() //choice item randomly in droptable
    {
        string result;
        int key = Random.Range(1, droptable.ItemList.Length);

        result = droptable.ItemList[key].itemName;
        return result;
    }

}
