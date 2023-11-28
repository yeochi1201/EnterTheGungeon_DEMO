using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    Camera minimapCam;
    Transform transform;
    Transform playerTransform;

    public GameObject playerUI;
    public GameObject minimapUI;

    public float xOffSet;
    public float yOffset;
    public float zOffSet;
    public float turnSpeed;
    private bool clickTab;
    
    void Awake() {
        minimapCam = gameObject.GetComponent<Camera>();
        transform = gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        turnSpeed = 2f;
    }
    void Start()
    {
        minimapUI.SetActive(false);
        playerUI.SetActive(true);
        clickTab = false;

        transform.position = playerTransform.position + Vector3.back * 10;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) {
            if(!clickTab) {
                playerUI.SetActive(false);
                minimapUI.SetActive(true);
                minimapCam.orthographicSize = 70f;
                transform.position = new Vector3(95, 50, -10);
                clickTab = true;
            }
            else {
                playerUI.SetActive(true);
                minimapUI.SetActive(false);
                minimapCam.orthographicSize = 20f;
                transform.position = playerTransform.position + Vector3.back * 10;
                clickTab = false;
            }
        }
        if(clickTab) {
            ZoomMap();
        }
    }
    void ZoomMap() {
        if(minimapCam.orthographicSize <= 70f) {
            if(Input.GetAxis("Mouse ScrollWheel") < 0) minimapCam.orthographicSize += 2f;
            if(Input.GetAxis("Mouse ScrollWheel") > 0) minimapCam.orthographicSize -= 2f;
        }
        else {
            minimapCam.orthographicSize = 70f;
        }
    }
}
