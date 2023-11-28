using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable : MonoBehaviour
{
   [SerializeField]
    DTAsset droptable;

    public void Drop()
    {
        GameObject item = ChoiceItem();
        Instantiate<GameObject>(item, GetComponentInParent<Transform>().transform);
    }

    public GameObject ChoiceItem() //choice item randomly in droptable
    {
        GameObject result;
        int key = Random.Range(0, droptable.droplist.Count);

        result = droptable.droplist[key];
        return result;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("E")&&collision.CompareTag("Player"))
        {
            Drop();
            Destroy(this.gameObject);
        }
    }
}
