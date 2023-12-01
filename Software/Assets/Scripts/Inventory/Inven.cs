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
    int blank = 2;
    public int maxActiveSlot = 6;
    int weaponIndex = 0;
    int activeIndex = 0;
    int gold = 0;

    void Start()
    {
        GameObject go = GameObject.Find("InvenUI");
        invenUI = go.GetComponent<InvenUI>();
        basicGun = Instantiate(basicGun);
        GetWeapon(basicGun);
        weapons[weaponIndex].GetComponent<WeaponItem>().PlayerGetGun();
        weapons[weaponIndex].GetComponent<WeaponItem>().OnEquip();
    }
    public void SwapWeapon(float wheelMove)
    {
        if (!invenUI.IsPaused)
        {
            weapons[weaponIndex].GetComponent<WeaponItem>().Unequip();
            if (wheelMove < 0)
            {
                weaponIndex++;
                if (weaponIndex == weapons.Count)
                    weaponIndex = 0;
            }
            if (wheelMove > 0)
            {
                weaponIndex--;
                if (weaponIndex == -1)
                    weaponIndex = weapons.Count - 1;
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
            if (activeIndex >= actives.Count)
            {
                activeIndex = 0;
            }
            Debug.Log($"{activeIndex}¹ø ÀåÂøÁß");
        }
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
                return;
            }
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
        if (!invenUI.IsPaused)
        {
            if (actives.Count == 0)
            {
                Debug.Log("No Item");
                return;
            }
            actives[activeIndex].GetComponent<ActiveItem>().Consume();
            actives.RemoveAt(activeIndex);
            invenUI.RemoveActiveButton(activeIndex);
            activeIndex -= 1;
            if (activeIndex == -1)
            {
                activeIndex = 0;
            }
            Debug.Log("Use Item");
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
        invenUI.AddPassiveButton(newPassive);
    }


    void IncreaseGold()
    {
        gold++;
    }


}
