using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class DropTable : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    [SerializeField]
    DTAsset droptable;

    public void Drop()
    {
        //load prefab and create gameobejct
    }

    public string ChoiceItem() //choice item randomly in droptable
    {
        string result;
        int key = Random.Range(1, droptable.ItemList.Length);

        result = droptable.ItemList[key].itemName;
        return result;
    }

}
