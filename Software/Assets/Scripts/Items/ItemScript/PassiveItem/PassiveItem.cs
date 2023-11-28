using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    virtual public void OnEquip()
    {
        
    }
    virtual public void UnEquip()
    {

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Inven inven = collision.GetComponentInParent<Inven>();
        if(Input.GetKeyDown("E") && collision.CompareTag("Player"))
        {
            collision.GetComponentInParent<PassiveItem>().OnEquip();
            inven.GetPassive(this.gameObject);
        }
    }
}
