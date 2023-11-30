using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] spwanPoints;

    [SerializeField]
    GameObject[] chests;

    [Header("Temp Test (Ignore Below Parameters)")]
    [Header("BrownChest")]
    [SerializeField]
    GameObject[] brownChests;

    [Range(0f, 1f)]
    [SerializeField]
    float brownSpawnRate;

    [Header("BlueChest")]
    [SerializeField]
    GameObject[] blueChests;
    [Range(0f, 1f)]
    [SerializeField]
    float blueSpawnRate;

    [Header("GreenChest")]
    [SerializeField]
    GameObject[] greenChests;
    [Range(0f, 1f)]
    [SerializeField]
    float greenSpawnRate;

    [Header("RedChest")]
    [SerializeField]
    GameObject[] redChests;
    [Range(0f, 1f)]
    [SerializeField]
    float redSpawnRate;


    public void SpawnChest()
    {
        foreach(GameObject obj in spwanPoints)
        {
            Instantiate(chests[Random.Range(0, 8)], obj.transform.position, Quaternion.identity);
        }
    }




}
