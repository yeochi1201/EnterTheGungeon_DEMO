using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {
        get {
            if(_instance == null) {
                _instance = FindObjectOfType<GameManager>();            
            }
            return _instance;
        }
    }
    private static GameManager _instance;

    private PlayerSpecification playerSpec;
    // public bool isGameOver { get; private set; }

    public int _currentHP; // 현재 체력
    public int _maxHP; // 현재 가질 수 있는 풀 체력

    public Image[] heart; // player가 가질 수 있는 최대 체력
    public Sprite fullHeart; 
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public int _currentBlank; // 현재 공포탄 수

    public Image[] blank; // 가질 수 있는 최대 공포탄 수

    public Text coinText;
    public Text keyText;

    // public GameObject gameOverUI;

    void Awake() {
        GameObject go = GameObject.Find("Player");
        playerSpec = go.GetComponent<PlayerSpecification>();
        //gameOverUI.SetActive(false);
    }
    
    void Update()
    {
        if(playerSpec.currentHP >= 0) {
            SetHpUI();
            SetBlankUI();
            SetCoinText();
            SetKeyText();
        }
        // else {
        //     gameOverUI.SetActive(true);
        // }
    }

    private void SetHpUI() {
        _currentHP = (int)playerSpec.currentHP / 2;
        _maxHP = (int)playerSpec.maxHP / 2;

        for(int i = 0; i < heart.Length; i++) {
            if(i < _maxHP / 2) {
                heart[i].gameObject.SetActive(true);
            }
            else {
                heart[i].gameObject.SetActive(false);
            }
        }
        for(int i = 0; i < _maxHP / 2; i++) {
            if(i < _currentHP / 2) heart[i].sprite = fullHeart;
            else {

                if(_currentHP % 2 == 1) heart[_currentHP / 2].sprite = halfHeart;
                else heart[i].sprite = emptyHeart;
            }
        }
    }

    private void SetBlankUI() {
        _currentBlank = playerSpec.currentBlank;

        for(int i = 0; i < blank.Length; i++) {
            if(i < _currentBlank) {
                blank[i].gameObject.SetActive(true);
            }
            else {
                blank[i].gameObject.SetActive(false);
            }
        }
    }

    private void SetCoinText() {
        coinText.text = playerSpec.gold.ToString();
    }
    private void SetKeyText() {
        keyText.text = playerSpec.key.ToString();
    }
}
