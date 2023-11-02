using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    public void EffectInit()
    {
        transform.position = transform.parent.position;
        transform.gameObject.SetActive(false);
    }
}
