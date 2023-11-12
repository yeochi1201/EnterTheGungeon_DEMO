
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    { 
    
        string othertag = collision.gameObject.tag;
        
        if(othertag == "enemy")
        {
            CollisionEnemy(collision);
        }
        else if (othertag == "bullet")
        {

        }
        //else if(othertag == "trap")
        //else if(othertag == "pit")
    }

    public virtual void CollisionEnemy(Collision2D collision)
    {
        GetDamaged(collision.gameObject.GetComponentInParent<Enemy>().damage);
    }

    public void GetDamaged(float damage)
    {
        GameObject go = GameObject.Find("Player");
        go.GetComponent<PlayerSpecification>().currentHP -= damage;
    }

}
