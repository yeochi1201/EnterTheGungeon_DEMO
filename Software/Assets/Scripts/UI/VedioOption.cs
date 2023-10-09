using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VedioOption : MonoBehaviour
{
    public Dropdown dropdown;
    List<Resolution> resolutions = new List<Resolution>();
    public int resolutionNum;
    void Start() {
        init();
    }
    void init() {
        for(int i = 0; i < Screen.resolutions.Length; i++) {
            if(Screen.resolutions[i].refreshRate == 60) {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
        dropdown.options.Clear();

        int optionNum = 0;
        foreach(Resolution item in resolutions) {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + " X " + item.height;
            dropdown.options.Add(option);
            
            if(item.width == Screen.width && item.height == Screen.height) {
                dropdown.value = optionNum;
            }
            optionNum++;
        }
        dropdown.RefreshShownValue();
    }
    public void DropboxOption(int x) {
        resolutionNum = x;
    }
    void Update() {
        
    }
}
