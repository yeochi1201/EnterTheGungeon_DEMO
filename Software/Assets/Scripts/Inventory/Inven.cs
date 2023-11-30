using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    public List<GameObject> actives = new List<GameObject>();
    public List<GameObject> passives = new List<GameObject>();
    [SerializeField] GameObject basicGun;
    [SerializeField] InvenUI invenUI;
    // int blank = 2;
    public int maxActiveSlot = 6;
    int weaponIndex = 0;
    int activeIndex = 0;
    int gold = 0;

    void Start()
    {
        GetWeapon(basicGun);
    }

    void Update()
    {

    }

    public void SwapWeapon(float wheelMove)
    {
        if (!invenUI.IsPaused)
        {
            weapons[weaponIndex].GetComponent<WeaponItem>().Unequip();
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
            weapons[weaponIndex].GetComponent<WeaponItem>().OnEquip();
        }
    }

    public void GetWeapon(GameObject newWeapon)
    {
        if (weapons.Count == 6)
        {
            Debug.Log("Inventory Full");
            return;
        }
        weapons.Add(newWeapon);
        invenUI.AddWeaponButton(newWeapon);
    }

    public void ThrowWeapon()
    {
        if (!invenUI.IsPaused)
        {
            if (weapons.Count == 1 || weaponIndex == 0)
            {
                Debug.Log("Throw Failed");
                return;
            }
            Debug.Log($"{weaponIndex + 1}번 무기 Throw");
            weapons[weaponIndex].SetActive(true);
            weapons[weaponIndex].transform.SetParent(null);

            weapons.RemoveAt(weaponIndex);
            invenUI.RemoveWeaponButton(weaponIndex);
            weaponIndex -= 1;
            if (weaponIndex == -1)
            {
                weaponIndex = weapons.Count - 1;
            }
        }

    }

    public void SwapActive()
    {
        if (!invenUI.IsPaused)
        {
            activeIndex++;
            if (activeIndex == actives.Count)
            {
                activeIndex = 0;
            }
            Debug.Log($"{activeIndex + 1}번 장착중");
        }


        // return actives[activeIndex];
    }

    public void GetActive(GameObject newActive)
    {
        if (actives.Count == maxActiveSlot)
        {
            Debug.Log("Inventory Full");
            return;
        }
        actives.Add(newActive);
        invenUI.AddActiveButton(newActive);
    }

    public void ThrowActive()
    {
        if (!invenUI.IsPaused)
        {
            if (actives.Count == 0)
            {
                Debug.Log("Throw Failed");
            }
            Debug.Log($"{activeIndex + 1}번 Active Item Thorw");
            actives[activeIndex].SetActive(true);
            actives[activeIndex].transform.SetParent(null);
            actives.RemoveAt(activeIndex);
            invenUI.RemoveActiveButton(activeIndex);
            activeIndex -= 1;
            if (activeIndex == -1)
            {
                activeIndex = 0;
            }
        }

    }

    public void UseAcitve()
    {
        actives[activeIndex].GetComponent<ActiveItem>().Consume();
    }

    public void GetPassive(GameObject newPassive)
    {
        if (passives.Count == 6)
        {
            Debug.Log("Inventory Full");
            return;
        }
        passives.Add(newPassive);
        invenUI.AddPassiveButton(newPassive);
    }


    void IncreaseGold()
    {
        gold++;
    }


}
