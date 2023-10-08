using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
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
        if(weapon.ammo_count == 0)
        {
            weapon.current_ammo = weapon.ammo_size;
        }
        else
        {
            if (weapon.current_ammo_count < weapon.ammo_size - weapon.current_ammo)
            {
                weapon.current_ammo = weapon.current_ammo_count;
                weapon.current_ammo_count = 0;
            }
            else
            {
                weapon.current_ammo_count -= (weapon.ammo_size - weapon.current_ammo);
                weapon.current_ammo = weapon.ammo_size;
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
}
