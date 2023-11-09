using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [Header("Camera Property")]
    [SerializeField] float cameraSpeed = 5.0f;
    float maxDistance = 3f;
    Transform playerTrans;
    Vector3 cameraPosition;
    Vector3 mouse;
    Vector3 offset;

    void Awake()
    {
        playerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();

        offset = transform.position - playerTrans.position;
    }

    void LateUpdate()
    {
        CameraControl();
    }

    void CameraControl()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = playerTrans.position.z;

        cameraPosition = ((mouse + playerTrans.position)/2);

        float distance = Vector3.Distance(mouse, playerTrans.position);

        if (distance > maxDistance)
        {
            Vector3 direction = (mouse - playerTrans.position).normalized;
            cameraPosition = playerTrans.position + direction * maxDistance;
        }
        cameraPosition.z = -10;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, cameraSpeed * Time.deltaTime);
    }
}
