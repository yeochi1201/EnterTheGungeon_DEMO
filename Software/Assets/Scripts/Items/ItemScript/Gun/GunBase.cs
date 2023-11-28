using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [SerializeField]

    public WeaponAsset weapon;
    
    public Bullet ammo;
    //�Ѿ� �߻�
    virtual public void SpecialEffect()
    {
        //bullet�� ���� �Ѱܼ� bullet pooler���� �߻�
    }
    //������
    public void Reload()
    {
        float time_start = Time.deltaTime;
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
                break;
            }
        }
        return;
    }
    //�Ѿ� �߻� ������
    public void Delay()
    {
        float time_start = Time.deltaTime;
        
        while (true)
        {
            if (Time.deltaTime - time_start >= weapon.delay)
            {
                break;
            }
        }
        return;
    }
    //Item ȹ�� ��
    public void Acquire()
    {
        //bullet pooler ���� (ũ�� : weapon.ammo_size
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
