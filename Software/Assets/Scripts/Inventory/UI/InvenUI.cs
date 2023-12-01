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
    public GameObject itemButton;
    Canvas canvas;
    bool activeInventory = false;
    bool isPaused;
    public bool IsPaused { get { return isPaused; } }
    void Start()
    {
        canvas = GetComponent<Canvas>();
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
                ChangeItemInfo();
                canvas.sortingOrder = 1;
            }

            if (activeInventory == false)
            {
                Time.timeScale = 1;
                isPaused = false;
                canvas.sortingOrder = 0;
            }
            inventory.SetActive(activeInventory);

        }
    }

    public void AddWeaponButton(GameObject newWeapon)
    {
        GameObject invenUI = GameObject.Find("InvenUI");
        Transform weaponFrame = Util.FindChild<Transform>(invenUI, "WeaponFrame", true);
        GameObject btn = Instantiate(itemButton);
        btn.transform.SetParent(weaponFrame);

        ItemButton itemBtnInfo = btn.GetComponent<ItemButton>();

        itemBtnInfo.itemName = newWeapon.GetComponent<WeaponItem>().weapon.itemName;
        itemBtnInfo.itemTitle = newWeapon.GetComponent<WeaponItem>().weapon.title;

        RectTransform buttonRectTransform = btn.GetComponent<RectTransform>();
        Sprite originalSprite = newWeapon.GetComponent<WeaponItem>().weapon.sprite;
        buttonRectTransform.sizeDelta = new Vector2(originalSprite.rect.width, originalSprite.rect.height);

        Image image = btn.GetComponent<Image>();

        image.sprite = originalSprite;
        weaponList.Add(btn);
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
        GameObject btn = Instantiate(itemButton);
        btn.transform.SetParent(acitveFrame);

        RectTransform buttonRectTransform = btn.GetComponent<RectTransform>();
        Sprite originalSprite = newActive.GetComponent<ActiveItem>().active.sprite;
        buttonRectTransform.sizeDelta = new Vector2(originalSprite.rect.width, originalSprite.rect.height);
    
        Image image = btn.GetComponent<Image>();

        image.sprite = originalSprite;
        activeList.Add(btn);
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
        GameObject btn = Instantiate(itemButton);
        btn.transform.SetParent(passiveFrame);

        RectTransform buttonRectTransform = btn.GetComponent<RectTransform>();
        Sprite originalSprite = newPassive.GetComponent<PassiveItem>().passive.sprite;
        buttonRectTransform.sizeDelta = new Vector2(originalSprite.rect.width, originalSprite.rect.height);

        Image image = btn.GetComponent<Image>();

        image.sprite = originalSprite;
        passiveList.Add(btn);
    }

    public void ChangeItemInfo()
    {
        GameObject invenUI = GameObject.Find("InvenUI");
        Image itemImage = Util.FindChild<Image>(invenUI, "ItemImage", true);
        RectTransform buttonRectTransform = weaponList[0].GetComponent<RectTransform>();
        RectTransform itemRectTransform = itemImage.GetComponent<RectTransform>();
        Image image = weaponList[0].GetComponent<Image>();

        itemRectTransform.sizeDelta = buttonRectTransform.sizeDelta;
        itemImage.sprite = image.sprite;
    }
}


