using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [Header("Camera Property")]
    [SerializeField] float cameraSpeed = 2;
    float maxDistance = 3f;
    public Transform playerTransform;
    Vector3 cameraPosition;
    Vector3 mouse;
    Vector3 offset;

    void Awake()
    {
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        CameraControl();
    }

    void CameraControl()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = playerTransform.position.z;

        cameraPosition = ((mouse + playerTransform.position)/2);

        float distance = Vector3.Distance(mouse, playerTransform.position);

        if (distance > maxDistance)
        {
            Vector3 direction = (mouse - playerTransform.position).normalized;
            cameraPosition = playerTransform.position + direction * maxDistance;
        }
        cameraPosition.z = -10;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, cameraSpeed * Time.deltaTime);
    }
}
