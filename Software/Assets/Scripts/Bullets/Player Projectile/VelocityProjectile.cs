using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityProjectile : Projectile
{
    protected override void FixedUpdate() 
    {
        ProjectileMove();
        ProjectileRotate();
    }

    protected override void ProjectileMove()
    {
        base.ProjectileMove();
        projectileRigidbody.velocity = projectileDirection * projectileSpeed * 50 * Time.deltaTime;
    }
}
