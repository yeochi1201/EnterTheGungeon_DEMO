using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : Projectile
{
    private float m_lifetime = 0;
    public float m_frequency = 10;
    public float m_amplitude = 2;
    bool isLeft;

    Vector2 PerpDirection;
    void Start()
    {
        PerpDirection = new Vector2(-projectileDirection.y, projectileDirection.x);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ProjectileMove();
        ProjectileRotate();
    }

    protected override void ProjectileMove()
    {
        base.ProjectileMove();
        projectileRigidbody.velocity = GetProjectileVelocity(5, m_lifetime, m_frequency, m_amplitude);
        m_lifetime += Time.fixedDeltaTime;
    }

    public void SetProjectileProperty(string _weaponName, bool _isLeft, int _damage, float _speed, float _range, float _force, int _pierce, int _bounce, Vector2 _direction)
    {
        isLeft = _isLeft;       
        ProjectileElement projectileElement = projectileData.projectileElement[_weaponName];
        projectileDamage = _damage;
        projectileSpeed = _speed;
        projectileRange = _range;
        projectileForce = _force;
        projectilePierce = _pierce;
        projectileBounce = _bounce;
        projectileDirection = _direction;
        SetData(projectileElement);
    }

    private Vector2 GetProjectileVelocity(float _xspeed, float _time, float _frequency, float _amplitude)
    {

        Vector2 PerpDirectionNormalized = PerpDirection.normalized;
        float perpspeed;
        if (isLeft)
        {            
            perpspeed = Mathf.Cos(_time * _frequency) * _amplitude * _frequency;
        }
        else
        {            
            perpspeed = -Mathf.Cos(_time * _frequency) * _amplitude * _frequency;
        }

        return projectileDirection * _xspeed + PerpDirectionNormalized * perpspeed;
    }
}
