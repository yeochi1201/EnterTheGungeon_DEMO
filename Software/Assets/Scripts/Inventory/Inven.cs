using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    List<Weapon> weapons = new List<Weapon>();
    List<ConsumeItem> actives = new List<ConsumeItem>();
    Weapon basicGun;
    public GameObject script;
    // int blank = 2;
    int weaponIndex = 1;
    int activeIndex = 0;
    int gold = 0;

    void Start()
    {
        weapons.Add(basicGun);
    }

    void Update()
    {
        float wheelMove = Input.GetAxis("Mouse ScrollWheel");
        if (wheelMove != 0)
        {
            SwapWeapon(wheelMove);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwapActive();
        }
    }

    void SwapWeapon(float wheelMove)
    {
        Debug.Log($"{wheelMove}");
        if(wheelMove < 0)
        {
            weaponIndex++;
            if (weaponIndex == weapons.Count + 1)
                weaponIndex = 1;
            Debug.Log($"{weaponIndex}번 장착중");
            Debug.Log($"weapon리스트 크기 : {weapons.Count}");
        }
        if(wheelMove > 0)
        {
            weaponIndex--;
            if (weaponIndex == 0)
                weaponIndex = weapons.Count;
            Debug.Log($"{weaponIndex}번 장착중");
            Debug.Log($"weapon리스트 크기 : {weapons.Count}");
        }

        // return weapons[idx];
    }

    public void GetWeapon(Weapon newWeapon)
    {
       if (weapons.Count == 6) {
            Debug.Log("Inventory Full");
            return;
        }
        weapons.Add(newWeapon);
        // Managers.InvenUI.AddWeaponButton(newWeapon);
        script.GetComponent<ItemButton>().CreateButton();
    }

    public void ThrowWeapon()
    {
        if (weapons.Count == 1)
        {
            Debug.Log("Throw Failed");
            return;
        }
        Debug.Log($"{weaponIndex}번 무기 Throw");
        weapons.RemoveAt(weaponIndex - 1);
        weaponIndex -= 1;
    }

    void SwapActive()
    {
        activeIndex++;
        if (activeIndex == 6)
        {
            activeIndex = 0;
        }
        Debug.Log($"{activeIndex}번 장착중");

        // return actives[activeIndex];
    }

    public void GetActive(ConsumeItem newActive)
    {
        if (actives.Count == 5)
        {
            Debug.Log("Inventory Full");
            return;
        }
        actives.Add(newActive);
        // Managers.InvenUI.AddActiveButton(newActive);
        Managers.InvenUI.AddActiveButton(newActive);
    }

    void ThrowActive()
    {
        if (actives.Count == 0)
            Debug.Log("Throw Failed");
        actives.RemoveAt(activeIndex);
    }

    void IncreaseGold()
    {
        gold++;
    }


}
