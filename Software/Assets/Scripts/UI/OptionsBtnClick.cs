using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsBtnClick : MonoBehaviour
{
    public GameObject[] startMenu;
    public GameObject option;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnClick() {
        for(int i = 0; i < startMenu.Length; i++) {
            startMenu[i].SetActive(false);
        }
        option.SetActive(true);
    }

}
