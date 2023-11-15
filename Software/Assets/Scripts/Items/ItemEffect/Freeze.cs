using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public GameObject go;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            if(go.GetComponent<PlayerSpecification>() != null)
            {
                go.GetComponent<PlayerSpecification>().speed -= 0.2f;
            }
            else if (go.GetComponent<Enemy>()!=null)
            {
                go.GetComponent<Enemy>().speed -= 0.2f;
            }
        }
    }
}
