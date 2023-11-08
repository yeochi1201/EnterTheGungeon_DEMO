using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
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
                else if (collision.GetComponentInParent<PotionAsset>() != null)
                {
                    if(collision.GetComponentInParent<PotionAsset>().passive != false)
                    {
                        collision.GetComponentInParent<PotionItem>().OnEquip();
                    }
                }
            }
        }
    }
}
