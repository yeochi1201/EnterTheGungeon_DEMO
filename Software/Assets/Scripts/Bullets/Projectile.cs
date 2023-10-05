using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use for Player Projectile
public class Projectile : MonoBehaviour
{
    [SerializeField] protected ProjectileType projectileType;
    [SerializeField] protected float projectileDamage;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float projectileRange; //expired range
    [SerializeField] protected float projectileForce; //knockback
    [SerializeField] protected int projectilePierce; //through count
    [SerializeField] protected int projectileBounce; //bounce count (ex: wall)
    
    protected SpriteRenderer projectileSpriteRenderer;
    protected Rigidbody2D projectileRigidbody;
    protected Collider2D projectileCollider;
    protected Vector2 projectileDirection;        

    protected virtual void Awake()
    {
        projectileRigidbody = transform.GetComponent<Rigidbody2D>();
        projectileCollider = transform.GetComponent<Collider2D>();
        projectileSpriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    protected virtual void Start() { }

    protected virtual void FixedUpdate() { }
    
    public void SetProjectileProperty(ProjectileType _projectileType, float _damage, float _speed, float _range, float _force, int _pierce, int _bounce, Vector2 _direction)
    {
        projectileType = _projectileType;
        projectileDamage = _damage;
        projectileSpeed = _speed;
        projectileRange = _range;
        projectileForce = _force;
        projectilePierce = _pierce;
        projectileBounce = _bounce;
        projectileDirection = _direction;        
    }

    protected virtual void ProjectileMove() { }

    protected virtual void ProjectileRotate()
    {
        transform.up = projectileDirection;
    }

    protected virtual void ProjectileInit()
    {
        transform.SetParent(transform.parent);        
        projectileDamage = 0;
        projectileSpeed = 0;
        projectileRange = 0;
        projectileForce = 0;
        projectilePierce = 0;
        projectileBounce = 0;
        projectileDirection = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if(projectilePierce > 0) //Pierce
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
