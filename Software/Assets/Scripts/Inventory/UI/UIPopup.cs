using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : UIBase
{
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject.gameObject, true);
    }

    public virtual void ClosePopUI()
    {
        Managers.UI.ClosePopupUI(this);
    }
}
