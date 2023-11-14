using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    { 
    
        string othertag = collision.gameObject.tag;
        GameObject go = GameObject.Find("Player");
        PlayerSpecification ps = go.GetComponent<PlayerSpecification>();
        if(othertag == "enemy")
        {
            if (!ps.contactArmor)
            {
                CollisionEnemy(collision, ps);
            }
            
        }
        else if (othertag == "bullet")
        {
            
        }
        else if(othertag == "trap")
        {
            if(!ps.trapArmor)
            {
                CollisionTrap(collision, ps);
            }
        }
        else if(othertag == "pit")
        {
            if (!ps.pitArmor)
            {
                CollisionPit(collision, ps);
            }
            ps.superArmor = true;
        }
    }

    public virtual void CollisionEnemy(Collision2D collision, PlayerSpecification ps)
    {
        GetDamaged(collision.gameObject.GetComponentInParent<Enemy>().damage, ps);
    }

    public virtual void CollisionTrap(Collision2D collision, PlayerSpecification ps)
    {
        //GetDamaged(collision.gameObject.GetComponentInParent<Trap>().damage, ps);
    }

    public virtual void CollisionPit(Collision2D collision, PlayerSpecification ps)
    {
        //GetDamaged(collision.gameObject.GetComponentInParent<Pit>().damage, ps);
    }

    public void GetDamaged(float damage, PlayerSpecification ps)
    { 
        ps.currentHP -= damage;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string othertag = collision.gameObject.tag;
        GameObject go = GameObject.Find("Player");
        PlayerSpecification ps = go.GetComponent<PlayerSpecification>();

        if (othertag == "Pit")
        {
            ps.superArmor = false;
        }
    }
}