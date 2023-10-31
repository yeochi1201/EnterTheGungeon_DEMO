using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProjectile : Projectile
{
    float duration = 359f;
    float hue;

    protected override void Start()
    {
        base.Start();
        hue = 0f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ProjectileMove();
        ChangeProjectileColor();
        ProjectileRotate();
    }

    protected override void ProjectileMove()
    {
        base.ProjectileMove();
        projectileRigidbody.velocity = projectileDirection * projectileSpeed * 20 * Time.deltaTime;
    }

    void ChangeProjectileColor()
    {
        hue = (Time.time * duration) % 360f;

        projectileSpriteRenderer.color = Color.HSVToRGB(hue / 360f, 0.3f, 1f);
    }
}
