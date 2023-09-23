using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMG : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;

    public void Spawn(string name)
    {
        GameObject go = Instantiate(Resources.Load(name, typeof(GameObject)))as GameObject;
        go.transform.position = parent.transform.position;

        go.SetActive(true);
    }
}
