using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtnClick : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnClick() {
        SceneManager.LoadScene("GamePlay");
        Debug.Log("OnClick!");
    }
}
