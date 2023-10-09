using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayOption : MonoBehaviour
{
    [SerializeField] Texture2D[] cursorImgs;
    [SerializeField] Sprite[] cursorSprite;
    [SerializeField] Image img;

    public GameObject[] startMenu;

    int i = 0;
    
    void Update()
    {
        Cursor.SetCursor(cursorImgs[i], new Vector2(cursorImgs[i].width / 2, cursorImgs[i].height / 2), CursorMode.Auto);
        img.sprite = cursorSprite[i];
    }

    public void LeftBtnClick() {
        if(--i < 0) i = cursorImgs.Length - 1;
    }
    public void RightBtnClick() {
        if(++i > cursorImgs.Length - 1) i = 0;
    }
    public void CancelBtnClick() {
        i = 0;
        Cursor.SetCursor(cursorImgs[i], new Vector2(cursorImgs[i].width / 2, cursorImgs[i].height / 2), CursorMode.Auto);
        img.sprite = cursorSprite[i];
        
        gameObject.SetActive(false);

        for(int j = 0; j < startMenu.Length; j++) {
            startMenu[j].SetActive(true);
        }
    }
    public void ResetBtnClick() {
        i = 0;
    }
    public void ConfirmBtnClick() {
        gameObject.SetActive(false);

        for(int j = 0; j < startMenu.Length; j++) {
            startMenu[j].SetActive(true);
        }
    }
}
