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

    public float turnSpeed;
    private bool clickTab;
    
    void Awake() {
        minimapCam = gameObject.GetComponent<Camera>();
        transform = gameObject.GetComponent<Transform>();
        turnSpeed = 2f;
    }
    void Start()
    {
        minimapUI.SetActive(false);
        playerUI.SetActive(true);
        clickTab = false;
        
        minimapCam.orthographicSize = 20f;
    }

    void Update()
    {
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerTransform = player.GetComponent<Transform>();
                transform.position = playerTransform.position + Vector3.back * 10;
            }
        }
        else
        {
            if (clickTab)
            {
                ZoomMap();
                Teleport();
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Camera.main.GetComponent<CameraController>().enabled = true;
                    playerUI.SetActive(true);
                    minimapUI.SetActive(false);
                    minimapCam.orthographicSize = 20f;
                    transform.position = playerTransform.position + Vector3.back * 10;
                    clickTab = false;
                }
            }
            else
            {
                transform.position = playerTransform.position + Vector3.back * 10;
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Camera.main.GetComponent<CameraController>().enabled = false;
                    playerUI.SetActive(false);
                    minimapUI.SetActive(true);
                    minimapCam.orthographicSize = 70f;
                    transform.position = new Vector3(95, 50, -10);
                    clickTab = true;
                }
            }
        }
    }
    void ZoomMap() {
        if(minimapCam.orthographicSize <= 70f && minimapCam.orthographicSize >= 20f) {
            // 마우스 위치 가져오기
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = minimapCam.transform.position.z;

            // 마우스 위치를 월드 좌표로 변환
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // 드래그 앤 드롭
            if (Input.GetMouseButton(0)) {
                float turnSpeed = 2f; // 조절 가능한 드래그 앤 드롭 속도
                minimapCam.transform.position = new Vector3(
                    Mathf.Clamp(minimapCam.transform.position.x - Input.GetAxis("Mouse X") * turnSpeed, 0, 150),
                    Mathf.Clamp(minimapCam.transform.position.y - Input.GetAxis("Mouse Y") * turnSpeed, 0, 80),
                    minimapCam.transform.position.z
                );
            }

            // 줌인, 줌아웃 처리
            if (Input.GetAxis("Mouse ScrollWheel") < 0) {
                minimapCam.orthographicSize += 2f;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0) {
                minimapCam.orthographicSize -= 2f;
                minimapCam.transform.position = Vector3.Lerp(minimapCam.transform.position, worldMousePos, 0.5f * Time.deltaTime);
                // minimapCam.transform.position = new Vector3(95 + worldMousePos.x * turnSpeed, 50 + worldMousePos.y * turnSpeed, minimapCam.transform.position.z);
            } 
        } else {
            if(minimapCam.orthographicSize > 70f) 
                minimapCam.orthographicSize = 70f;
            if(minimapCam.orthographicSize < 20f)
                minimapCam.orthographicSize = 20f;
        }
    }

    void Teleport() {
        if (Input.GetMouseButtonDown(0))
		{
			Vector2 worldPoint = minimapCam.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);

			if (hit.collider != null && hit.collider.gameObject.tag == "Teleporter") {
                Debug.Log("Teleport!!");
                Vector3 teleportPosition = hit.collider.transform.position;
                playerTransform.position = teleportPosition;
                Camera.main.transform.position = playerTransform.position + Vector3.back * 10;
                Camera.main.GetComponent<CameraController>().enabled = true;
                playerUI.SetActive(true);
                minimapUI.SetActive(false);
                minimapCam.orthographicSize = 20f;
                transform.position = playerTransform.position + Vector3.back * 10;
                clickTab = false;
            }     
		}
    }
}
