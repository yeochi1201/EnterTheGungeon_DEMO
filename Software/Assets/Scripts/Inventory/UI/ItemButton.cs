using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButton : UIPopup
{
    enum Buttons
    {
        ImageButton
    }
    enum Images
    {
        ItemIcon
    }
    public override void Init()
    {
        base.Init();

        // Bind<Button>(typeof(Buttons));
        // Bind<Image>(typeof(Images));

        // GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);
    }

    public void CreateButton()
    {
        Transform itemBtn = Managers.Resource.Instantiate("itemButton").transform;
        GameObject invenUI = GameObject.Find("InvenUI");
        GameObject weaponFrame = Util.FindChild(invenUI, "WeaponFrame", true);
        Transform itemSort = Util.FindChild<Transform>(weaponFrame, "ItemSort", true);
        itemBtn.SetParent(itemSort);
    }


    public void OnButtonClicked(PointerEventData data)
    {

    }
}
