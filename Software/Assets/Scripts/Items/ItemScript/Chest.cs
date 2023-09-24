using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public ChestAsset info;
    public GameObject chest;

    public void setInstance(int floor) //set chest rank
    {
        int keycode = Random.Range(1, 1000);
        if(floor == 1 || floor == 2)
        {
            if(keycode <= 4)
            {
                chest = Instantiate(chest); //S
            }
            else if(keycode <= 13)
            {
                chest = Instantiate(chest); //A
            }
            else if (keycode <= 53)
            {
                chest = Instantiate(chest); //B
            }
            else if (keycode <= 90)
            {
                chest = Instantiate(chest); //C
            }
            else if (keycode <= 100)
            {
                chest = Instantiate(chest); //D
            }

        }
    }

    public void OpenChest() //open the chest
    {
        
    }
}
