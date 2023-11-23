using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTargetCollider : MonoBehaviour
{
    CircleCollider2D detectCollider;
    float radius;

    private void Awake()
    {
        detectCollider = GetComponent<CircleCollider2D>();
    }

    public void SetRadius(float _radius)
    {
        radius = _radius;
        detectCollider.radius = radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            transform.parent.GetComponent<HomingProjectile>().SetTarget(collision.transform);
        }
    }
}
