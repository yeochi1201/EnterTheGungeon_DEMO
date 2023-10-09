using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option2Detail : MonoBehaviour
{
    public GameObject gamePlayOption;
    public GameObject controlOption;
    public GameObject vedioOption;
    public GameObject audioOption;
    
    public void GamePlayBtnClick() {
        gameObject.SetActive(false);
        gamePlayOption.SetActive(true);
    }
    public void ControlBtnClick() {
        gameObject.SetActive(false);
        controlOption.SetActive(true);
    }
    public void VedioBtnClick() {
        gameObject.SetActive(false);
        vedioOption.SetActive(true);
    }
    public void AudioBtnClick() {
        gameObject.SetActive(false);
        audioOption.SetActive(true);
    }
}
