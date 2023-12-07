using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Button itemButton;
    public string itemName;
    public string itemTitle;
    public string itemType;
    public string itemDescription;
    private void Start()
    {
        itemButton.onClick.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        Debug.Log("Button Click!!!");
        GameObject invenUI = GameObject.Find("InvenUI");
        Image itemImage = Util.FindChild<Image>(invenUI, "ItemImage", true);
        Text name = Util.FindChild<Text>(invenUI, "ItemName", true);
        Text title = Util.FindChild<Text>(invenUI, "ItemTitle", true);
        Text description = Util.FindChild<Text>(invenUI, "ItemDescription", true);
        name.text = itemName;
        title.text = itemTitle;
        description.text = itemDescription;

        RectTransform buttonRectTransform = itemButton.GetComponent<RectTransform>();
        RectTransform imageSize = itemImage.GetComponent<RectTransform>();
        imageSize.sizeDelta = new Vector2(buttonRectTransform.rect.width, buttonRectTransform.rect.height);

        itemImage.sprite = itemButton.image.sprite;

    }
}
