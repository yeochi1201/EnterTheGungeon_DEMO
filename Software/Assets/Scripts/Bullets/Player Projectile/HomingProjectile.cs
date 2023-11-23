using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile
{
    float visionDecisionValue;
    float detectAngle = Mathf.PI * 0.5f;
    float towardValue = Mathf.PI * 2f;
    float distance = 5f;
    float angle;
    Vector2 homingDirection;
    Transform target;    
    
    protected override void Start()
    {
        visionDecisionValue = Mathf.Cos(detectAngle * .5f);
        transform.GetChild(0).GetComponent<DetectTargetCollider>().SetRadius(distance);
    }

    protected override void FixedUpdate()
    {
        if (target != null)
        {
            HomingTarget();
        }
        else
        {
            ProjectileRotate();
        }
        ProjectileMove();
        
        DrawDetectAngle();
    }

    void DrawDetectAngle()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.RotateTowards(transform.up, transform.right, detectAngle * .5f, 0f) * distance, Color.red);

        Debug.DrawRay(transform.position, Vector3.RotateTowards(transform.up, -transform.right, detectAngle * .5f, 0f) * distance, Color.red);
    }


    protected override void ProjectileMove()
    {
        base.ProjectileMove();
        projectileRigidbody.velocity = projectileDirection * projectileSpeed * 50 * Time.deltaTime;
    }

    protected override void ProjectileRotate()
    {
        transform.up = projectileDirection;
    }

    void HomingTarget()
    {
        homingDirection = (target.position - transform.position).normalized;

        if (Vector2.Dot(transform.up, homingDirection) > visionDecisionValue)
        {
            float singleStep = towardValue * 0.5f * Time.deltaTime;
            projectileDirection = Vector3.RotateTowards(transform.up, homingDirection, singleStep, 0.0f);            
            angle = Mathf.Atan2(homingDirection.y, homingDirection.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    protected override void ProjectileInit()
    {
        BulletImpact();
        transform.SetParent(transform.parent);
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        projectileDamage = 0;
        projectileSpeed = 0;
        projectileRange = 0;
        projectileForce = 0;
        projectilePierce = 0;
        projectileBounce = 0;
        projectileDirection = Vector2.zero;
        target = null;
    }
}
