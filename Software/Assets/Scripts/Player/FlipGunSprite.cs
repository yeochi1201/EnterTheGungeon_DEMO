using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGunSprite : MonoBehaviour
{
    public SpriteRenderer[] gunsprite;

    void Update()
    {
        gunsprite = this.GetComponentsInChildren<SpriteRenderer>();
        FlipSprite();
    }

    void FlipSprite()
    {
        if (gunsprite != null)
        {
            if (transform.rotation.z > 0.75f || transform.rotation.z < -0.75f)
            {
                for (int i = 0; i < gunsprite.Length; i++)
                {
                    gunsprite[i].flipY = true;
                }
            }

            else
            {
                for (int i = 0; i < gunsprite.Length; i++)
                {
                    gunsprite[i].flipY = false;
                }
            }
        }

    }
}
