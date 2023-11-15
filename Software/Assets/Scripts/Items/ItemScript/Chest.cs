using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public ChestAsset info;
    public DropTable dt;
    private void OnDestroy()
    {
        dt.Drop();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                OnDestroy();
            }
        }
    }
}
