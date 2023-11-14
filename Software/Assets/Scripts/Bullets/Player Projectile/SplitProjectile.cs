using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitProjectile : Projectile
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
    
    protected override void ProjectileRotate()
    {
        if(projectileName == "Lil'Bomber")
        {
            transform.Rotate(0, 0, 90 * Time.deltaTime * 2);
        }
        else
        {
            transform.up = projectileDirection;
        }
    }
    protected override void ProjectileInit()
    {
        BulletImpact(projectileName);
        transform.SetParent(transform.parent);
        projectileDamage = 0;
        projectileSpeed = 0;
        projectileRange = 0;
        projectileForce = 0;
        projectilePierce = 0;
        projectileBounce = 0;
        projectileDirection = Vector2.zero;
    }

    protected void BulletImpact(string _bulletName)
    {
        GameObject _effect;

        switch (_bulletName)
        {
            case "Lil'Bomber":
                _effect = EffectPooler.Instance.GetEffect(EffectType.EXPLOSION_IMPACT);
                _effect.transform.position = transform.position;
                _effect.SetActive(true);
                break;
            case "BigShotgun":
                _effect = EffectPooler.Instance.GetEffect(EffectType.SPLIT_IMPACT);
                _effect.transform.position = transform.position;
                _effect.SetActive(true);
                break;
            default:
                break;
        }
    }
        
    
}
