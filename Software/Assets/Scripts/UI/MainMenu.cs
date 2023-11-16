using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject[] gameObjects;
    void Awake() {
        for(int i = 0; i < this.transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 0; i < gameObjects.Length; i++) {
            gameObjects[i].SetActive(true);
        }
    }
}
