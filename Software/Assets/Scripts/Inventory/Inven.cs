using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    public List<GameObject> actives = new List<GameObject>();
    public List<GameObject> passives = new List<GameObject>();
    GameObject basicGun;
    [SerializeField] InvenUI invenUI;
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
        
    }

    public void SwapWeapon(float wheelMove)
    {
        if (!invenUI.IsPaused)
        {
            Debug.Log($"{wheelMove}");
            if (wheelMove < 0)
            {
                weaponIndex++;
                if (weaponIndex == weapons.Count)
                    weaponIndex = 0;
                Debug.Log($"{weaponIndex + 1}�� ������");
                Debug.Log($"weapon����Ʈ ũ�� : {weapons.Count}");
            }
            if (wheelMove > 0)
            {
                weaponIndex--;
                if (weaponIndex == -1)
                    weaponIndex = weapons.Count - 1;
                Debug.Log($"{weaponIndex + 1}�� ������");
                Debug.Log($"weapon����Ʈ ũ�� : {weapons.Count}");
            }
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
        if (!invenUI.IsPaused)
        {
            if (weapons.Count == 1 || weaponIndex == 0)
            {
                Debug.Log("Throw Failed");
                return;
            }
            Debug.Log($"{weaponIndex + 1}�� ���� Throw");
            weapons[weaponIndex].SetActive(true);
            weapons[weaponIndex].transform.SetParent(null);

            weapons.RemoveAt(weaponIndex);
            Managers.InvenUI.RemoveWeaponButton(weaponIndex);
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

        }
        activeIndex++;
        if (activeIndex == actives.Count)
        {
            activeIndex = 0;
        }
        Debug.Log($"{activeIndex + 1}�� ������");

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
        if (!invenUI.IsPaused)
        {
            if (actives.Count == 0)
            {
                Debug.Log("Throw Failed");
            }
            Debug.Log($"{activeIndex + 1}�� Active Item Thorw");
            actives[activeIndex].SetActive(true);
            actives[activeIndex].transform.SetParent(null);
            actives.RemoveAt(activeIndex);
            Managers.InvenUI.RemoveActiveButton(activeIndex);
            activeIndex -= 1;
            if (activeIndex == -1)
            {
                activeIndex = 0;
            }
        }
        
    }
    public void GetPassive(GameObject newPassive)
    {
        if (passives.Count == 6)
        {
            Debug.Log("Inventory Full");
            return;
        }
        passives.Add(newPassive);
        Managers.InvenUI.AddPassiveButton(newPassive);
    }


    void IncreaseGold()
    {
        gold++;
    }


}
