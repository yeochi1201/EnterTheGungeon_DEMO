using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public enum ProjectilePatternType
{
    CIRCLE,
    CIRCLE_ROTATE,
    CIRCLE_LUMP,
    TEXT,
    MAZE,
    CIRCLE_CROSS,
    CIRCLE_REVERSE,
}

//for Boss
public class ProjectilePattern : MonoBehaviour
{
    [SerializeField] ProjectilePatternType projectilePatternType;
    [SerializeField] GameObject muzzle;
    Vector2 muzzleDirection;
    //CIRCLE Properties
    int bulletCount;
    float distance;
    int angleInterval;

    //CIRCLE_LUMP Properties    
    [SerializeField] Transform target;

    private void Update()
    {
        muzzleDirection = muzzle.transform.right;
        if (Input.GetMouseButtonDown(0))
        {
            PatternStart();
        }

    }

    void PatternStart() //*
    {
        switch (projectilePatternType)
        {
            case ProjectilePatternType.CIRCLE:
                StartCoroutine(CirclePattern(30, 6));
                break;
            case ProjectilePatternType.CIRCLE_ROTATE:
                StartCoroutine(CircleRotatePattern(30, 3));
                break;
            case ProjectilePatternType.CIRCLE_LUMP:
                bulletCount = 30;
                angleInterval = 360 / bulletCount;
                for (int i = 1; i <= bulletCount; i++)
                {
                    GameObject bullet = BulletPooler.Instance.GetBullet(BulletOwner.ENEMY);
                    bullet.transform.position = muzzle.transform.position;
                    bullet.GetComponent<Bullet>().SetDirection(muzzle.transform.right);
                    muzzle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInterval * i));
                    bullet.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    IEnumerator CirclePattern(int _bulletCount, int patternCount)//Pattern 2 or higher -> cross pattern, bulletSpeed = 8f
    {
        if (patternCount <= 1)
        {
            bulletCount = _bulletCount;
            angleInterval = 360 / bulletCount;
            for (int i = 0; i < patternCount; i++)
            {
                for (int j = 1; j <= bulletCount; j++)
                {
                    muzzleDirection = muzzle.transform.right;
                    GameObject _projectile = ProjectilePooler.Instance.GetProjectile(ProjectileType.ENEMY_ANOMALY);
                    _projectile.GetComponent<AnomalyProjectile>().SetProjectileProperty("EnemyBasic", 1, 10, 40, 0, 0, 0, muzzleDirection);
                    _projectile.transform.position = muzzle.transform.position;
                    _projectile.gameObject.SetActive(true);

                    muzzle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInterval * j));
                }
            }
        }
        else if (patternCount > 1)
        {
            bulletCount = _bulletCount;
            angleInterval = 360 / bulletCount;

            for (int i = 0; i < patternCount; i++)
            {
                for (int j = 1; j <= bulletCount; j++)
                {
                    if (i % 2 == 0)
                    {
                        muzzle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInterval * (j + 0.5f)));
                    }
                    else
                    {
                        muzzle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInterval * j));
                    }
                    muzzleDirection = muzzle.transform.right;
                    GameObject _projectile = ProjectilePooler.Instance.GetProjectile(ProjectileType.ENEMY_ANOMALY);
                    _projectile.GetComponent<AnomalyProjectile>().SetProjectileProperty("EnemyBasic", 1, 10, 40, 0, 0, 0, muzzleDirection);
                    _projectile.transform.position = muzzle.transform.position;
                    _projectile.gameObject.SetActive(true);
                }

                yield return new WaitForSeconds(.3f);

            }
        }

    }

    IEnumerator CircleRotatePattern(int _bulletCount, int patternCount) //
    {
        bulletCount = _bulletCount;
        angleInterval = 360 / bulletCount;

        for (int i = 0; i < patternCount; i++)
        {
            for (int j = 1; j <= bulletCount; j++)
            {
                yield return new WaitForSeconds(0.05f);

                GameObject bullet = BulletPooler.Instance.GetBullet(BulletOwner.ENEMY);
                bullet.transform.position = muzzle.transform.position;
                bullet.GetComponent<Bullet>().SetDirection(muzzle.transform.right);
                bullet.gameObject.SetActive(true);

                muzzle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInterval * j));

            }
        }

    }

    IEnumerator CircleLumpPattern(int _bulletCount, int patternCount)
    {
        return null;
    }

}
