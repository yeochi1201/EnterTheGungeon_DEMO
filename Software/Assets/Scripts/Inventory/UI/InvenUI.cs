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
        GameObject btn = Instantiate(itemButton, transform);
        btn.transform.SetParent(weaponFrame);

        RectTransform buttonRectTransform = btn.GetComponent<RectTransform>();
        Sprite originalSprite = newWeapon.GetComponent<SpriteRenderer>().sprite;
        buttonRectTransform.sizeDelta = new Vector2(originalSprite.rect.width, originalSprite.rect.height);

        weaponList.Add(btn);
        Image image = btn.GetComponent<Image>();

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
        GameObject btn = Instantiate(itemButton, transform);
        btn.transform.SetParent(acitveFrame);

        RectTransform buttonRectTransform = btn.GetComponent<RectTransform>();
        Sprite originalSprite = newActive.GetComponent<SpriteRenderer>().sprite;
        buttonRectTransform.sizeDelta = new Vector2(originalSprite.rect.width, originalSprite.rect.height);

        activeList.Add(btn);
        Image image = btn.GetComponent<Image>();

        image.sprite = originalSprite;
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
        GameObject btn = Instantiate(itemButton, transform);
        btn.transform.SetParent(passiveFrame);

        RectTransform buttonRectTransform = btn.GetComponent<RectTransform>();
        Sprite originalSprite = newPassive.GetComponent<SpriteRenderer>().sprite;
        buttonRectTransform.sizeDelta = new Vector2(originalSprite.rect.width, originalSprite.rect.height);

        passiveList.Add(btn);
        Image image = btn.GetComponent<Image>();

        image.sprite = originalSprite;
    }
}


