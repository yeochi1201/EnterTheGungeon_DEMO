using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // TODO : 버튼 이미지 추가
    public void AddWeaponButton(Weapon item)
    {
        GameObject invenUI = GameObject.Find("InvenUI");
        GameObject weaponFrame = Util.FindChild(invenUI, "WeaponFrame", true);
        Transform itemSort = Util.FindChild<Transform>(weaponFrame, "ItemSort", true);
        Managers.Resource.Instantiate("itemButton", itemSort);
    }

    public void AddActiveButton(ConsumeItem item)
    {
        GameObject invenUI = GameObject.Find("InvenUI");
        GameObject acitveFrame = Util.FindChild(invenUI, "ActiveFrame", true);
        Transform itemSort = Util.FindChild<Transform>(acitveFrame, "ItemSort", true);
        Managers.Resource.Instantiate("itemButton", itemSort);
    }

    void RemoveItemButton(Weapon item)
    {
        /*
         * TODO
         * Destroy()
         */
    }
}
