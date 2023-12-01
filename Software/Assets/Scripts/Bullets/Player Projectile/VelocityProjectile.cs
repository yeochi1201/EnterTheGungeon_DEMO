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

    
}
