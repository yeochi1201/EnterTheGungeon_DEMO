using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperProjectile : Projectile
{
    TrailRenderer trailRenderer;

    protected override void Awake()
    {
        base.Awake();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ProjectileMove();
    }

    protected override void ProjectileMove()
    {
        base.ProjectileMove();
        projectileRigidbody.velocity = projectileDirection * projectileSpeed * 20 * Time.deltaTime;
    }

    protected override void ProjectileInit()
    {
        base.ProjectileInit();
        trailRenderer.Clear();
    }
}
