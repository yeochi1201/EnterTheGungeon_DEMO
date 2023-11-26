using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    GameObject go = GameObject.Find("Player");
    PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
    private void OnCollisionEnter2D(Collision2D collision) 
    { 
        string othertag = collision.gameObject.tag;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (Input.GetKey(KeyCode.E))
            {
                //inventory¿¡ ÀåÂø
                if (collision.GetComponentInParent<PassiveAsset>() != null)
                {
                    collision.GetComponentInParent<PassiveItem>().OnEquip();
                }
                else if (collision.GetComponentInParent<ActiveAsset>() != null)
                {
                    if (collision.GetComponentInParent<ActiveAsset>().passive != false)
                    {
                        collision.GetComponentInParent<ActiveItem>().OnEquip();
                    }
                }
                else if (collision.GetComponentInParent<WeaponAsset>() != null)
                {
                    GunBase gun = collision.GetComponentInParent<GunBase>();
                    gun.WeaponUpdateAmmoSize(ps.ammo_size_buf);
                    gun.WeaponUpdateDegree(ps.ammo_degree_buf);
                    gun.WeaponUpdateDamage(ps.weapon_dmg_buf);
                    gun.WeaponUpdateReload(ps.weapon_reload_buf);
                    gun.WeaponUpdateDelay(ps.weapon_delay_buf);
                    gun.WeaponUpdateAmmoCount(ps.ammo_count_buf);
                }
            }
        }
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

    
}