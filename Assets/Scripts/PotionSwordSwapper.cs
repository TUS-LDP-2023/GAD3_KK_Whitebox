using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSwordSwapper : MonoBehaviour
{
    public Stab sword;
    public ThrowPotion potion;
    public StarterAssetsInputs inputs;

    void Update()
    {
        if(potion.listPos == 2)
        {
            sword.enabled = true;
            potion.enabled = false;
            if (inputs.Cycle == true)
            {
                inputs.Cycle = false;
                potion.listPos++;
            }
        } else
        {
            sword.enabled = false;
            potion.enabled = true;
        }
    }
}
