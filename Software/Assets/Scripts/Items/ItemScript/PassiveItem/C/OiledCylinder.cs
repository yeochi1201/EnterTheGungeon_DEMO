using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OiledCylinder : PassiveItem
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.weapon_reload_buf *= 1.20f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponUpdateReload(1.20f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpecification ps = GameObject.Find("Player").GetComponent<PlayerSpecification>();
        ps.weapon_reload_buf /= 1.20f;
        Inven inven = GameObject.Find("Player").GetComponent<Inven>();
        foreach (GameObject weapon in inven.weapons)
        {
            weapon.GetComponent<WeaponItem>().WeaponRollbackReload(1.20f);
        }
    }
}
