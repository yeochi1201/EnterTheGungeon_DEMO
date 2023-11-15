using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
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
                    if(collision.GetComponentInParent<ActiveAsset>().passive != false)
                    {
                        collision.GetComponentInParent<ActiveItem>().OnEquip();
                    }
                }
                else if (collision.GetComponentInParent<WeaponAsset>() != null)
                {
                    GunBase gun = collision.GetComponentInParent <GunBase>();
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
}
