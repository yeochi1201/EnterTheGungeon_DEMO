using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenUI : MonoBehaviour
{
    List<GameObject> weaponList = new List<GameObject>();
    List<GameObject> activeList = new List<GameObject>();
    List<GameObject> passiveList = new List<GameObject>();
    public GameObject inventory;
    bool activeInventory = false;
    bool isPaused;
    public bool IsPaused { get { return isPaused; } }
    void Start()
    {
        inventory.SetActive(activeInventory);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            if (activeInventory == true)
            {
                Time.timeScale = 0;
                isPaused = true;
            }

            if (activeInventory == false)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            inventory.SetActive(activeInventory);

        }
    }


    public void AddWeaponButton(GameObject newWeapon)
    {
        GameObject invenUI = GameObject.Find("InvenUI");
        Transform weaponFrame = Util.FindChild<Transform>(invenUI, "WeaponFrame", true);
        GameObject itemButton = Managers.Resource.Instantiate("Inventory/ItemButton", weaponFrame);

        RectTransform buttonRectTransform = itemButton.GetComponent<RectTransform>();
        Sprite originalSprite = newWeapon.GetComponent<SpriteRenderer>().sprite;
        buttonRectTransform.sizeDelta = new Vector2(originalSprite.rect.width, originalSprite.rect.height);

        weaponList.Add(itemButton);
        Image image = itemButton.GetComponent<Image>();

        Sprite weaponSprite = newWeapon.GetComponent<SpriteRenderer>().sprite;
        image.sprite = weaponSprite;
    }

    public void RemoveWeaponButton(int index)
    {
        Managers.Resource.Destroy(weaponList[index]);
        weaponList.RemoveAt(index);

    }
    public void AddActiveButton(GameObject newActive)
    {
        GameObject invenUI = GameObject.Find("InvenUI");
        Transform acitveFrame = Util.FindChild<Transform>(invenUI, "ActiveFrame", true);
        GameObject itemButton = Managers.Resource.Instantiate("Inventory/ItemButton", acitveFrame);

        activeList.Add(itemButton);
        Image image = itemButton.GetComponent<Image>();

        Sprite activeSprite = newActive.GetComponent<SpriteRenderer>().sprite;
        image.sprite = activeSprite;
    }

    public void RemoveActiveButton(int index)
    {
        Managers.Resource.Destroy(activeList[index]);
        activeList.RemoveAt(index);
    }

    public void AddPassiveButton(GameObject newPassive)
    {
        GameObject invenUI = GameObject.Find("InvenUI");
        Transform passiveFrame = Util.FindChild<Transform>(invenUI, "PassiveFrame", true);
        GameObject itemButton = Managers.Resource.Instantiate("Inventory/ItemButton", passiveFrame);

        passiveList.Add(itemButton);
        Image image = itemButton.GetComponent<Image>();

        Sprite activeSprite = newPassive.GetComponent<SpriteRenderer>().sprite;
        image.sprite = activeSprite;
    }
}
