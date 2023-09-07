using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public enum BulletType
{
    BASIC_SMALL, //±âº» Åº¸·
    BASIC_LARGE, //±âº» Å« Åº¸·
    ANOMALY, //º¯Ä¢ ¼Óµµ Åº¸·
    BLINK, //±ôºýÀÌ´Â Åº¸·
    TRAIL, //²¿¸®°¡ ÀÖ´Â Åº¸·
    MISSILE_GUIDED, //À¯µµ ¹Ì»çÀÏ
    MISSILE_HOWITZER, //°î»ç ¹Ì»çÀÏ
    LASER, //·¹ÀÌÀú
    TRIANGLE, //»ï°¢ Åº¸·
    SNAKE, //¹ì²¿¸® °ÔÀÓ Åº¸·
    WAG, //ÁÂ¿ì ÀÌµ¿ Åº¸·
    HE, //°íÆøÅº Åº¸·
    FLARE, //È­¿° Åº¸·    
    MAX_SIZE
}

public class Bullet : MonoBehaviour
{
    [Header("Bullet Type")]
    [SerializeField] public BulletType bulletType;

    [Header("Bullet Property")]
    [SerializeField] float bulletDamage;    
    [SerializeField][Range(0f, 100f)] float bulletSpeed;

    Rigidbody2D bulletRigidbody;
    Vector2 bulletDirection;
    float anomalyTime = 0f;

    [Header("Speed Check")]
    private Vector3 oldPosition;
    private Vector3 currentPosition;
    [SerializeField] double velocity;

    GameObject targetObject;
    Vector2 guidedDirection;
    float startGuideTime = 0f;

    private void Awake()
    {        
        bulletRigidbody = transform.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        bulletSpeed = 5f;
        oldPosition = transform.position;
    }

    private void FixedUpdate()
    {
        ProjectileMoving();
        SpeedCheck();        
    }

    void SpeedCheck() //½ºÇÇµå Ã¼Å©
    {
        currentPosition = transform.position;
        var dis = (currentPosition - oldPosition);
        var distance = Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2));
        velocity = distance / Time.deltaTime;
        oldPosition = currentPosition;
    }

    public void ProjectileMoving() //Åº¸· ¿òÁ÷ÀÓ
    {
        switch (bulletType)
        {
            case BulletType.BASIC_SMALL:
                bulletSpeed = 30f;
                bulletRigidbody.velocity = bulletDirection * bulletSpeed * 25 * Time.deltaTime;
                break;
            case BulletType.BASIC_LARGE:
                bulletSpeed = 30f;
                bulletRigidbody.velocity = bulletDirection * bulletSpeed * 25 * Time.deltaTime;
                break;
            case BulletType.ANOMALY:                
                anomalyTime += Time.deltaTime;                                
                bulletSpeed = Mathf.Abs(10 * Mathf.Sin(anomalyTime * 5));
                bulletRigidbody.velocity = bulletDirection * bulletSpeed * 25 * Time.deltaTime;
                break;
            case BulletType.MISSILE_GUIDED:                
                startGuideTime += Time.deltaTime;
                bulletRigidbody.velocity = bulletDirection * bulletSpeed * 25 * Time.deltaTime;
                if(startGuideTime > 0.5f)
                {
                    bulletDirection = GuideDirection();
                }                                
                break;
            default:
                Debug.Log("TYPE SET");
                break;
        }
    }

    public void GetDirection(Vector2 _direction) //ÃÑ±¸ ¹æÇâ
    {
        bulletDirection = _direction;
    }

    Vector2 GuideDirection()
    {
        targetObject = GameObject.Find("Target").gameObject; //Change Player
        guidedDirection = (targetObject.transform.position - transform.position).normalized;

        return guidedDirection;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Damaged()
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = transform.parent.position;
            this.gameObject.SetActive(false);
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            transform.position = transform.parent.position;            
            this.gameObject.SetActive(false);
        }
    }
}
