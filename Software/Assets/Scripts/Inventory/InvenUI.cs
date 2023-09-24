using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenUI : MonoBehaviour
{
    public GameObject inventory;
    bool activeInventory = false;
    void Start()
    {
        inventory.SetActive(activeInventory);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventory.SetActive(activeInventory);
        }
    }
}
