using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use for Player Projectile
public class Projectile : MonoBehaviour
{
    [SerializeField] protected ProjectileData projectileData;
    [SerializeField] protected ProjectileType projectileType;
    [SerializeField] protected string projectileName;
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

    protected BoxCollider2D boxCollider;
    protected CapsuleCollider2D capsuleCollider;
    protected CircleCollider2D circleCollider;

    protected float expiredTimer = 0;

    protected virtual void Awake()
    {
        projectileRigidbody = transform.GetComponent<Rigidbody2D>();
        projectileCollider = transform.GetComponent<Collider2D>();
        projectileSpriteRenderer = transform.GetComponent<SpriteRenderer>();
        boxCollider = transform.GetComponent<BoxCollider2D>();
        capsuleCollider = transform.GetComponent<CapsuleCollider2D>();
        circleCollider = transform.GetComponent<CircleCollider2D>();
    }

    protected virtual void Start() { }

    protected virtual void FixedUpdate() { }
    
    protected virtual void Update()
    {
        expiredTimer += Time.deltaTime * 2;
        if(expiredTimer > projectileRange)
        {
            ProjectileInit();
            expiredTimer = 0;
            gameObject.SetActive(false);
        }
    }

    public void SetProjectileProperty(string _weaponName, float _projectileDamage, int _projectileSpeed, int _projectileRange, int _projectileForce, int _pierce, int _bounce, Vector2 _direction)
    {
        ProjectileElement projectileElement = projectileData.projectileElement[_weaponName];
        projectileName = _weaponName;
        projectileDamage = _projectileDamage;
        projectileSpeed = _projectileSpeed;
        projectileRange = _projectileRange;
        projectileForce = _projectileForce;
        projectilePierce = _pierce;
        projectileBounce = _bounce;
        projectileDirection = _direction;
        SetData(projectileElement);        
    }

    protected void SetData(ProjectileElement _projectileElement)
    {
        projectileSpriteRenderer.sprite = _projectileElement.projectileSprite;
        switch (_projectileElement.colliderType)
        {
            case "BOX":
                boxCollider.enabled = true;
                capsuleCollider.enabled = false;
                circleCollider.enabled = false;
                boxCollider.size = new Vector3(_projectileElement.colliderSizeX, _projectileElement.colliderSizeY);
                break;
            case "CIRCLE":
                boxCollider.enabled = false;
                capsuleCollider.enabled = false;
                circleCollider.enabled = true;
                circleCollider.radius = _projectileElement.colliderSizeX;
                break;
            case "CAPSULE":
                boxCollider.enabled = false;
                capsuleCollider.enabled = true;
                circleCollider.enabled = false;
                capsuleCollider.size = new Vector3(_projectileElement.colliderSizeX, _projectileElement.colliderSizeY);
                break;
            default:
                break;
        }

    }

    protected virtual void ProjectileMove() 
    {
        projectileRigidbody.velocity = projectileDirection * projectileSpeed * 50 * Time.deltaTime;
    }
    protected virtual void BulletImpact()
    {
        GameObject _effect = EffectPooler.Instance.GetEffect(EffectType.BULLET_IMPACT);
        _effect.transform.position = transform.position;
        _effect.SetActive(true);
    }

    protected virtual void ProjectileRotate()
    {
        transform.up = projectileDirection;
    }

    protected virtual void ProjectileInit()
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
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
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
                collision.GetComponent<Enemy>().GetDamage(projectileDamage);

                projectilePierce--;
            }
            else
            {
                ProjectileInit();
                collision.GetComponent<Enemy>().GetDamage(projectileDamage);
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
