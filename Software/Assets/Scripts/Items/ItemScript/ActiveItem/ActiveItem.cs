using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    [SerializeField]
    public ActiveAsset active;
    virtual public void OnEquip()
    {

    }
    virtual public void UnEquip()
    {

    }
    virtual public void Consume()
    {

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        Inven inven = collision.GetComponentInParent<Inven>();
        if (Input.GetKeyDown(KeyCode.E) && collision.CompareTag("Player"))
        {
            this.gameObject.GetComponentInParent<ActiveItem>().OnEquip();
            inven.GetPassive(this.gameObject);
        }
        this.gameObject.SetActive(false);
        this.gameObject.transform.SetParent(collision.gameObject.transform);
    }
}
