using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicProjectile : Projectile
{
    protected override void FixedUpdate() 
    {
        ProjectileMove();
        ProjectileRotate();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (projectileBounce > 0) //Bounce
            {
                List<RaycastHit2D> hits = new List<RaycastHit2D>();

                projectileRigidbody.Cast(projectileDirection, hits, 5f); //distance val is temp

                Vector2 normalVector = hits[0].normal;
                Vector2 reflectDirection = Vector2.Reflect(projectileDirection, normalVector);
                projectileDirection = reflectDirection;

                projectileBounce--;
            }
            else
            {
                //returnProjectilePooler
                ProjectileInit();
                gameObject.SetActive(false);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (projectilePierce > 0) //Pierce
            {
                //collision.GetComponent<>().GetDamage(projectileDamage);

                projectilePierce--;
            }
            else
            {
                ProjectileInit();
                //collision.GetComponent<>().GetDamage(projectileDamage);
            }
        }
        /*
        else if(collision.gameObject.CompareTag("Box"))
        {
            //collision.GetComponent<>().GetDamage();
        }
        else if(collision.gameObject.CompareTag("SecretWall"))
        {
            //collision.GetComponent<>().GetDamage();
        }
        */

    }

}
