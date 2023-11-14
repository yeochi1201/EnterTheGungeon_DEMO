using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float speed = 10.0f;
    Rigidbody2D rigid;
    Inven inven;
    Weapon weapon;
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        inven = GetComponent<Inven>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            inven.ThrowWeapon();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            inven.ThrowActive();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.tag == "Weapon")
            {
                Debug.Log("Weapon Collision");
                GameObject newWeapon = other.gameObject;
                inven.GetWeapon(newWeapon);
            }
            if (other.tag == "ConsumeItem")
            {
                Debug.Log("ConsumeItem Collision");
                GameObject newActive = other.gameObject;
                inven.GetActive(newActive);
            }
        }
    }

}
