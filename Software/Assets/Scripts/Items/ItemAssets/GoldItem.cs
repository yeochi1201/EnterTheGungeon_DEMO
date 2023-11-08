using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldItem : MonoBehaviour
{
    public int amount;
    public PlayerSpecification playerSpec;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            playerSpec.gold += amount;
        }
    }
}
