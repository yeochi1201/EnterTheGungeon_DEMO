using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum BulletPattern
{
    CIRCLE,    
    CIRCLE_LUMP,
    TEXT,
    MAZE,
    CIRCLE_CROSS,
    CIRCLE_REVERSE,
}


public class BulletPatternManager : MonoBehaviour
{
    [SerializeField] BulletPattern bulletPattern;
    [SerializeField] GameObject muzzle;

    //CIRCLE Properties
    int bulletCount;
    float distance;
    int angleInterval;


    private void Awake()
    {
        
    }

    private void Start()
    {
        
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PatternStart();
        }

    }

    void PatternStart() //
    {
        switch(bulletPattern)
        {
            case BulletPattern.CIRCLE:
                    StartCoroutine(Interval());
                break;
            case BulletPattern.CIRCLE_LUMP:
                angleInterval = 360 / bulletCount;
                for (int i = 1; i <= bulletCount; i++)
                {
                    GameObject bullet = BulletPooler.Instance.GetBullet(BulletOwner.PLAYER);
                    bullet.transform.position = muzzle.transform.position;
                    bullet.GetComponent<Bullet>().SetDirection(muzzle.transform.right);
                    bullet.gameObject.SetActive(true);
                    muzzle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInterval * i));                    
                }                
                break;
            default:
                break;
        }        
    }

    IEnumerator Interval() //Interval shooting Bullet WIP
    {
        bulletCount = 30;

        angleInterval = 720 / bulletCount;
        for (int i = 1; i <= bulletCount; i++)
        {            
            GameObject bullet = BulletPooler.Instance.GetBullet(BulletOwner.PLAYER);
            bullet.transform.position = muzzle.transform.position;
            bullet.GetComponent<Bullet>().SetDirection(muzzle.transform.right);            
            muzzle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInterval * i));
            bullet.gameObject.SetActive(true);            
        }
        yield return new WaitForSeconds(0.1f);
        bulletCount = 30;
        angleInterval = 360 / bulletCount;  
        for (int i = 1; i <= bulletCount; i++)
        {            
            GameObject bullet = BulletPooler.Instance.GetBullet(BulletOwner.PLAYER);
            bullet.transform.position = muzzle.transform.position;
            bullet.GetComponent<Bullet>().SetDirection(muzzle.transform.right);
            muzzle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInterval * i));
            bullet.gameObject.SetActive(true);
        }
        
    }
}
