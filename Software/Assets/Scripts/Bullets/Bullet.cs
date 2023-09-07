using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using static UnityEngine.GraphicsBuffer;


public enum BulletType
{
    BASIC_SMALL, //Basic Bullet
    BASIC_LARGE, //Basic Big Bullet
    ANOMALY, //Anomaly Speed Bullet
    WAG, //Horizontal Moving Bullet
    MISSILE_GUIDED, //Guided Missile
    MISSILE_HOWITZER, //Howitzer Missile
    BLINK, //Blingking Bullet
    TRAIL, //Trail Bullet       
    LASER, //Laser
    TRIANGLE, //Triangle Shape Bullet
    SNAKE, //Snake Tail Game Bullet    
    HE, //HEAT Bullet
    FLARE, //Flare Bullet   
    MAX_SIZE
}

public class Bullet : MonoBehaviour
{
    [CustomEditor(typeof(Bullet))]
    public class BulletInspector : Editor //Display by Bullet Type(Custom Editor)
    {
        public override void OnInspectorGUI()
        {
            Bullet bullet = (Bullet)target;
            
            EditorGUILayout.LabelField("Bullet Type", EditorStyles.boldLabel);
            bullet.bulletType = (BulletType)EditorGUILayout.EnumPopup("Bullet Type", bullet.bulletType);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Common Bullet Properties", EditorStyles.boldLabel);
            bullet.bulletSpeed = EditorGUILayout.FloatField("Bullet Speed", bullet.bulletSpeed);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField(bullet.bulletType + " Type Properties", EditorStyles.boldLabel);
            //Properties by Type
            switch (bullet.bulletType)
            {
                case BulletType.BASIC_SMALL:
                    break;
                case BulletType.BASIC_LARGE:
                    break;                
                case BulletType.ANOMALY:                    
                    bullet.anomalyTime = EditorGUILayout.FloatField("Anomaly Time", bullet.anomalyTime);
                    break;
                case BulletType.WAG:
                    break;                
                case BulletType.MISSILE_GUIDED:
                    bullet.startGuideTime = EditorGUILayout.FloatField("Start Guide Time", bullet.startGuideTime);
                    break;
                case BulletType.MISSILE_HOWITZER:
                    bullet.startGuideTime = EditorGUILayout.FloatField("Start Impact Time", bullet.startGuideTime);
                    break;
                default:
                    break;
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(bullet);
            }
        }
    }

    //Bullet Type
    [SerializeField] public BulletType bulletType;
    
    //Common Bullet Properties
    [SerializeField] float bulletDamage;    
    [SerializeField] [Range(0f, 100f)] float bulletSpeed;

    Rigidbody2D bulletRigidbody;
    Vector2 bulletDirection;

    [Header("Speed Check")]
    Vector3 oldPosition;
    Vector3 currentPosition;
    [SerializeField] double velocity;

    //ANOMALY Properties
    float anomalyTime = 0f;
   
    //MISSILE_GUIDED Properties
    GameObject targetObject;
    Vector2 guidedDirection;
    float startGuideTime = 0f;

    //MISSILE_HOWITZER Properties
    float impactTime = 2f;


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

    void SpeedCheck() //Speed Check
    {
        currentPosition = transform.position;
        var dis = (currentPosition - oldPosition);
        var distance = Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2));
        velocity = distance / Time.deltaTime;
        oldPosition = currentPosition;
    }

    public void ProjectileMoving() //Bullet Move
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
            case BulletType.MISSILE_HOWITZER:   
                transform.gameObject.GetComponent<Collider2D>().enabled = false;
                bulletSpeed = 30f;
                bulletRigidbody.velocity = Vector2.up * bulletSpeed * 25 * Time.deltaTime;
                break;
            case BulletType.WAG:

                break;
            default:
                Debug.Log("TYPE SET");
                break;
        }
    }

    public void GetDirection(Vector2 _direction) //Muzzle Direction
    {
        bulletDirection = _direction;
    }

    Vector2 GuideDirection() //Missle Guide Direction
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
