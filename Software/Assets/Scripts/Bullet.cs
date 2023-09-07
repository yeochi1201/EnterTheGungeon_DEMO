using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public enum BulletType
{
    BASIC_SMALL, //�⺻ ź��
    BASIC_LARGE, //�⺻ ū ź��
    ANOMALY, //��Ģ �ӵ� ź��
    BLINK, //�����̴� ź��
    TRAIL, //������ �ִ� ź��
    MISSILE_GUIDED, //���� �̻���
    MISSILE_HOWITZER, //��� �̻���
    LASER, //������
    TRIANGLE, //�ﰢ ź��
    SNAKE, //�첿�� ���� ź��
    WAG, //�¿� �̵� ź��
    HE, //����ź ź��
    FLARE, //ȭ�� ź��    
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

    void SpeedCheck() //���ǵ� üũ
    {
        currentPosition = transform.position;
        var dis = (currentPosition - oldPosition);
        var distance = Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2));
        velocity = distance / Time.deltaTime;
        oldPosition = currentPosition;
    }

    public void ProjectileMoving() //ź�� ������
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
                //Vector
                break;
            default:
                Debug.Log("TYPE SET");
                break;
        }
    }

    public void GetDirection(Vector2 _direction) //�ѱ� ����
    {
        bulletDirection = _direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Damaged()
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            //Damaged()
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            transform.position = transform.parent.position;            
            this.gameObject.SetActive(false);
        }
    }
}
