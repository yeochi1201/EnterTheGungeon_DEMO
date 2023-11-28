using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Sprite openedSprite_left;
    [SerializeField]
    Sprite closedSprite_left;
    [SerializeField]
    GameObject leftdoor;
    [SerializeField]
    GameObject rightdoor;

    public void Open()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        leftdoor.GetComponent<SpriteRenderer>().sprite= openedSprite_left;
        leftdoor.transform.Translate(new Vector2(-0.4f, 0));
        rightdoor.GetComponent<SpriteRenderer>().sprite = openedSprite_left;
        rightdoor.GetComponent<SpriteRenderer>().flipX = true;
        rightdoor.transform.Translate(new Vector2(0.4f, 0));
        
    }
    public void Close()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        leftdoor.GetComponent<SpriteRenderer>().sprite = closedSprite_left;
        leftdoor.transform.Translate(new Vector2(0.4f, 0));
        rightdoor.GetComponent<SpriteRenderer>().sprite = closedSprite_left;
        rightdoor.GetComponent<SpriteRenderer>().flipX = true;
        rightdoor.transform.Translate(new Vector2(-0.4f, 0));
    }
}
