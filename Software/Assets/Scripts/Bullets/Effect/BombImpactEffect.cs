using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombImpactEffect : Effect
{
    int damage;

    public void SetDamage(int _damage)
    {
        damage = _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //collision.GetComponent<Enemy>().GetDamkaged(damage);
        }
    }
}
