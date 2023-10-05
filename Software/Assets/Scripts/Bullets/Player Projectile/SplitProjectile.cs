using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitProjectile : Projectile
{
    protected override void ProjectileMove()
    {
        base.ProjectileMove();
        projectileRigidbody.velocity = projectileDirection * projectileSpeed * Time.deltaTime;
    }
}
