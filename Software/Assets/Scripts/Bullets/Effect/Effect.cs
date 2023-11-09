using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public void EffectInitialization()
    {
        transform.position = transform.parent.position;
        transform.gameObject.SetActive(false);
    }
}
