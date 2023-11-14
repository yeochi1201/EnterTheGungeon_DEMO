using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenUI : MonoBehaviour
{
    List<GameObject> weaponList = new List<GameObject>();
    List<GameObject> activeList = new List<GameObject>();
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


    public void AddWeaponButton(GameObject newWeapon)
    {
        GameObject invenUI = GameObject.Find("InvenUI");
        Transform weaponFrame = Util.FindChild<Transform>(invenUI, "WeaponFrame", true);
        // Transform itemSort = Util.FindChild<Transform>(weaponFrame, "ItemSort", true);
        GameObject go = Managers.Resource.Instantiate("itemButton", weaponFrame);
        weaponList.Add(go);
        Image image = go.GetComponent<Image>();

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
        // Transform itemSort = Util.FindChild<Transform>(acitveFrame, "ItemSort", true);
        GameObject go = Managers.Resource.Instantiate("itemButton", acitveFrame);
        activeList.Add(go);
        Image image = go.GetComponent<Image>();

        Sprite activeSprite = newActive.GetComponent<SpriteRenderer>().sprite;
        image.sprite = activeSprite;
    }

    public void RemoveActiveButton(int index)
    {
        Managers.Resource.Destroy(activeList[index]);
        activeList.RemoveAt(index);
    }
}
