using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    GameObject spwanPoint;
    [SerializeField]
    GameObject chestSpawner;
    [SerializeField]
    GameObject palyer;


    void Start()
    {
        Instantiate(palyer, spwanPoint.transform.position, Quaternion.identity);
        chestSpawner.GetComponent<ChestSpawner>().SpawnChest();

    }


    


}
