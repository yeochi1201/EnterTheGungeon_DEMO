using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButton : UIPopup
{
    public Button itemButton;

    private void Start()
    {
        itemButton.onClick.AddListener(OnButtonClicked);
    }
    public override void Init()
    {
        base.Init();

    }

    public void OnButtonClicked()
    {
        Debug.Log("Button Click!!!");
        GameObject invenUI = GameObject.Find("InvenUI");
        Image itemImage = Util.FindChild<Image>(invenUI, "ItemImage", true);

        itemImage.sprite = itemButton.image.sprite;

    }
}
