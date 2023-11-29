using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    [SerializeField]
    public WeaponAsset weapon;
    private bool is_reload;
    private bool is_delay;
    public Bullet ammo;
    private GameObject muzzle;
    private Vector2 muzzle_direction;
    private bool is_equip = false;


    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetKeyDown(KeyCode.E) && collision.CompareTag("Player"))
        {
            Inven inven = collision.GetComponentInParent<Inven>();
            if (inven.weapons.Count < 6)
            {
                PlayerSpecification ps = collision.GetComponentInParent<PlayerSpecification>();
                WeaponUpdateDegree(ps.ammo_degree_buf);
                WeaponUpdateAmmoCount(ps.ammo_count_buf);
                WeaponUpdateAmmoSize(ps.ammo_size_buf);
                WeaponUpdateDamage(ps.weapon_dmg_buf);
                WeaponUpdateDelay(ps.weapon_delay_buf);
                WeaponUpdateReload(ps.weapon_reload_buf);
                inven.GetWeapon(this.gameObject);
                PlayerGetGun();
            }
        }
    }

    public void PlayerGetGun()
    {
        GameObject gunPivot = GameObject.Find("Player").transform.GetChild(0).gameObject;
        this.gameObject.transform.SetParent(gunPivot.transform);
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
        this.gameObject.transform.position = gunPivot.transform.position;
        this.gameObject.transform.rotation = gunPivot.transform.rotation;
        this.gameObject.SetActive(false);
    }
    public void OnEquip()
    {
        is_equip = true;
        this.gameObject.SetActive(true);
        ProjectilePooler.Instance.type = (ProjectileType)weapon.proejctileType;
        muzzle.transform.localPosition = weapon.muzzle_loc;
    }
    public void Unequip()
    {
        is_equip = false;
        this.gameObject.SetActive(false);
    }
    public void fire()
    {
        if (Input.GetMouseButtonDown(0) && is_equip)
            if (!is_delay && !is_reload)
            {
                if (!is_delay && !is_reload)
                {
                    muzzle_direction = muzzle.transform.right;
                    GameObject _projectile = ProjectilePooler.Instance.GetProjectile(ProjectilePooler.Instance.type);
                    _projectile.GetComponent<Projectile>().SetProjectileProperty(weapon.name, weapon.damage, weapon.ammo_speed, weapon.range, 0, 0, 0, muzzle_direction);
                    _projectile.transform.position = muzzle.transform.position;
                    _projectile.gameObject.SetActive(true);
                    weapon.current_ammo_size -= 1;
                }
            }
    }
    private void Reload()
    {
        if(weapon.current_ammo_count == 0)
        {
            return;
        }
        float time_start = Time.deltaTime;
        is_reload = true;
        if(weapon.ammo_count == -1)
        {
            weapon.current_ammo_size = weapon.ammo_size;
        }
        else
        {
            if (weapon.current_ammo_count < weapon.ammo_size - weapon.current_ammo_size)
            {
                weapon.current_ammo_size = weapon.current_ammo_count;
                weapon.current_ammo_count = 0;
            }
            else
            {
                weapon.current_ammo_count -= (weapon.ammo_size - weapon.current_ammo_size);
                weapon.current_ammo_size = weapon.ammo_size;
            }
        }

        while(true)
        {
            if(Time.deltaTime - time_start >= weapon.reload)
            {
                is_reload = false;
                break;
            }
        }
        return;
    }
    private void Delay()
    {
        float time_start = Time.deltaTime;
        is_delay = true;
        while (true)
        {
            if (Time.deltaTime - time_start >= weapon.delay)
            {
                is_delay = false;
                break;
            }
        }
        return;
    }

    public void WeaponUpdateDegree(float ammo_degree_buf)
    {
        weapon.current_degree = (int)(weapon.current_degree * ammo_degree_buf);
    }

    public void WeaponUpdateDamage(float weapon_damage_buf)
    {
        weapon.damage = weapon.damage * weapon_damage_buf;
    }

    public void WeaponUpdateAmmoSize(float ammo_size_buf)
    {
        weapon.current_ammo_size = (int)(weapon.current_ammo_size * ammo_size_buf);
    }

    public void WeaponUpdateReload(float weapon_reload_buf)
    {
        weapon.reload = (weapon.reload * weapon_reload_buf);
    }

    public void WeaponRollbackDegree(float ammo_degree_buf)
    {
        weapon.current_degree = (int)(weapon.current_degree / ammo_degree_buf);
    }

    public void WeaponRollbackDamage(float weapon_damage_buf)
    {
        weapon.damage = weapon.damage / weapon_damage_buf;
    }

    public void WeaponRollbackAmmoSize(float ammo_size_buf)
    {
        weapon.current_ammo_size = (int)(weapon.current_ammo_size / ammo_size_buf);
    }

    public void WeaponRollbackReload(float weapon_reload_buf)
    {
        weapon.reload = (weapon.reload / weapon_reload_buf);
    }

    public void WeaponUpdateDelay(float weapon_delay_buf)
    {
        weapon.delay = (weapon.delay * weapon_delay_buf);
    }

    public void WeaponRollbackDelay(float weapon_delay_buf)
    {
        weapon.delay = weapon.delay / weapon_delay_buf;
    }

    public void WeaponUpdateAmmoCount(float ammo_count_buf)
    {
        weapon.ammo_count = (int)(weapon.ammo_count * ammo_count_buf);
    }

    public void WeaponRollbackAmmoCount(float ammo_count_buf)
    {
        weapon.ammo_count = (int)(weapon.ammo_count / ammo_count_buf);
    }
}
