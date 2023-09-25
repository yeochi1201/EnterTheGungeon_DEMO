using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;
using static UnityEngine.GraphicsBuffer;


public class Bullet : MonoBehaviour
{
    [SerializeField] BulletData bulletData;

    Rigidbody2D bulletRigidbody;
    Vector2 bulletDirection;
    SpriteRenderer spriteRenderer;

    float bulletSpeed;
    float expiredTimer = 3f;
    float expiredTime = 0f;

    //ANOMALY Properties
    float anomalyTime = 0f;

    //MISSILE_GUIDED Properties
    GameObject targetObject;
    Vector2 guidedDirection;
    float startGuideTime = 0f;

    private void Awake()
    {
        bulletRigidbody = transform.GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = bulletData.BulletSprite;
    }

    private void FixedUpdate()
    {
        UpdateBulletMove();
    }

    void BulletMove() //Common Bullet Movement
    {
        bulletRigidbody.velocity = bulletDirection * bulletData.BulletSpeed * 25 * Time.deltaTime;
    }


    public void SetDirection(Vector2 _direction) //Muzzle Direction
    {
        bulletDirection = _direction;
    }

    Vector2 GetGuideDirection() //Missle Guide Direction
    {
        targetObject = GameObject.Find("Target").gameObject; //Change Player
        guidedDirection = (targetObject.transform.position - transform.position).normalized;

        return guidedDirection;
    }

    public void BulletExpired() //Bullet Expired
    {
        transform.position = transform.parent.position;
        this.gameObject.SetActive(false);
    }

    public void UpdateBulletMove() //Moving by Bullet Type
    {
        switch (bulletData.BulletType)
        {
            case BulletType.BASIC_SMALL:
            case BulletType.BASIC_LARGE:
                BulletMove();
                break;
            case BulletType.ANOMALY:
                anomalyTime += Time.deltaTime;
                bulletSpeed = Mathf.Abs(10 * Mathf.Sin(anomalyTime * 5));
                BulletMove();
                break;
            case BulletType.MISSILE_GUIDED:
                startGuideTime += Time.deltaTime;
                expiredTime += Time.deltaTime;
                BulletMove();

                if (startGuideTime > 0.5f)
                {
                    bulletDirection = GetGuideDirection();
                }

                if (expiredTime > expiredTimer)
                {
                    BulletExpired();
                    startGuideTime = 0;
                    expiredTime = 0;
                }
                break;
            case BulletType.BOUNCE:
                expiredTimer = 5f;
                expiredTime += Time.deltaTime;
                BulletMove();
                if (expiredTimer < expiredTime)
                {
                    BulletExpired();
                    expiredTime = 0;
                }
                break;
            default:
                Debug.Log("TYPE SET");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bulletData.BulletType != BulletType.BOUNCE)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //Damaged()
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                BulletExpired();
            }
            else if (collision.gameObject.CompareTag("Wall"))
            {
                BulletExpired();
            }
        }
        else if (bulletData.BulletType == BulletType.BOUNCE)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                bulletDirection *= -1;
            }
        }

    }
}