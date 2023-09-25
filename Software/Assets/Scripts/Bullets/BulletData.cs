using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletType
{
    BASIC_SMALL, //Basic Bullet
    BASIC_LARGE, //Basic Big Bullet
    ANOMALY, //Anomaly Speed Bullet
    ZIGZAG, //Horizontal Moving Bullet
    MISSILE_GUIDED, //Guided Missile
    //MISSILE_HOWITZER, //Howitzer Missile
    BOUNCE, //Bounce Bullet
    SPIRAL, //Spiral Bullet
    //BLINK, //Blingking Bullet
    //TRAIL, //Trail Bullet       
    //LASER, //Laser
    //TRIANGLE, //Triangle Shape Bullet
    //SNAKE, //Snake Tail Game Bullet    
    //HE, //HEAT Bullet
    //FLARE, //Flare Bullet   
    MAX_SIZE
}

[CreateAssetMenu(fileName = "Bullet Data", menuName = "Scriptable Object/Bullet Data", order = int.MaxValue)]
public class BulletData : ScriptableObject
{
    [SerializeField] BulletType bulletType;
    public BulletType BulletType { get { return bulletType; } }

    [SerializeField] float bulletSpeed;
    public float BulletSpeed { get { return bulletSpeed; } }

    [SerializeField] Sprite bulletSprite;
    public Sprite BulletSprite { get { return bulletSprite; } }

}