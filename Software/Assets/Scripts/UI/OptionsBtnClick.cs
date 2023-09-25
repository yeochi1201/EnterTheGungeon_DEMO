using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsBtnClick : MonoBehaviour
{
    public GameObject[] btns;
    public GameObject logo;
    public GameObject option;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnClick() {
        for(int i = 0; i < btns.Length; i++) {
            btns[i].SetActive(false);
        }
        logo.SetActive(false);
        option.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
