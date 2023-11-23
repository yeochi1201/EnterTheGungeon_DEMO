using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    public List<GameObject> actives = new List<GameObject>();
    public List<GameObject> passives = new List<GameObject>();
    GameObject basicGun;
    // int blank = 2;
    int weaponIndex = 0;
    int activeIndex = 0;
    int gold = 0;

    void Start()
    {
        GetWeapon(basicGun);
    }

    void Update()
    {
        /*float wheelMove = Input.GetAxis("Mouse ScrollWheel");
        if (wheelMove != 0)
        {
            SwapWeapon(wheelMove);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwapActive();
        }*/
    }

    public void SwapWeapon(float wheelMove)
    {
        Debug.Log($"{wheelMove}");
        if (wheelMove < 0)
        {
            weaponIndex++;
            if (weaponIndex == weapons.Count)
                weaponIndex = 0;
            Debug.Log($"{weaponIndex + 1}번 장착중");
            Debug.Log($"weapon리스트 크기 : {weapons.Count}");
        }
        if (wheelMove > 0)
        {
            weaponIndex--;
            if (weaponIndex == -1)
                weaponIndex = weapons.Count - 1;
            Debug.Log($"{weaponIndex + 1}번 장착중");
            Debug.Log($"weapon리스트 크기 : {weapons.Count}");
        }

        // return weapons[idx];
    }

    public void GetWeapon(GameObject newWeapon)
    {
        if (weapons.Count == 6)
        {
            Debug.Log("Inventory Full");
            return;
        }
        weapons.Add(newWeapon);
        Managers.InvenUI.AddWeaponButton(newWeapon);
    }

    public void ThrowWeapon()
    {
        if (weapons.Count == 1 || weaponIndex == 0)
        {
            Debug.Log("Throw Failed");
            return;
        }
        Debug.Log($"{weaponIndex + 1}번 무기 Throw");
        weapons.RemoveAt(weaponIndex);
        Managers.InvenUI.RemoveWeaponButton(weaponIndex);
        weaponIndex -= 1;
        if (weaponIndex == -1)
        {
            weaponIndex = weapons.Count - 1;
        }
    }

    public void SwapActive()
    {
        activeIndex++;
        if (activeIndex == actives.Count)
        {
            activeIndex = 0;
        }
        Debug.Log($"{activeIndex + 1}번 장착중");

        // return actives[activeIndex];
    }

    public void GetActive(GameObject newActive)
    {
        if (actives.Count == 6)
        {
            Debug.Log("Inventory Full");
            return;
        }
        actives.Add(newActive);
        Managers.InvenUI.AddActiveButton(newActive);
    }

    public void ThrowActive()
    {
        if (actives.Count == 0)
        {
            Debug.Log("Throw Failed");
        }
        Debug.Log($"{activeIndex + 1}번 Active Item Thorw");
        actives.RemoveAt(activeIndex);
        Managers.InvenUI.RemoveActiveButton(activeIndex);
        activeIndex -= 1;
        if (activeIndex == -1)
        {
            activeIndex = 0;
        }
    }

    public void GetPassive(GameObject newPassive)
    {
        passives.Add(newPassive);
        Managers.InvenUI.AddPassiveButton(newPassive);
    }

    void IncreaseGold()
    {
        gold++;
    }


}
