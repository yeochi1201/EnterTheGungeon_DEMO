using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitImpactEffect : Effect
{
    [SerializeField] GameObject muzzle;

    int bulletCount;
    int angleInterval;
    float damage;

    public void Split(int _bulletCount)
    {
        StartCoroutine(SplitCoroutine(_bulletCount));
    }

    public void SetDamage(int _damage)
    {
        damage = _damage;
    }

    IEnumerator SplitCoroutine(int _bulletCount)
    {
        bulletCount = _bulletCount;
        angleInterval = 360 / bulletCount;

        for (int j = 1; j <= bulletCount; j++)
        {
            GameObject _projectile = ProjectilePooler.Instance.GetProjectile(ProjectileType.VELOCITY);
            _projectile.transform.position = muzzle.transform.position;
            _projectile.GetComponent<VelocityProjectile>().SetProjectileProperty("Robot'sRightHand", 5.5f, 25, 20, 5, 0, 0, muzzle.transform.right);
            _projectile.gameObject.SetActive(true);

            muzzle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInterval * j));
        }
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //collision.GetComponent<Enemy>().GetDamkaged(damage);
        }
    }
}