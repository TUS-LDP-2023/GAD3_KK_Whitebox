using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour
{

    public Animator animator;
    public StarterAssetsInputs inputs;

    private void Update()
    {
        if(inputs.throwP == true)
        {
            inputs.throwP = false;
            animator.SetTrigger("Stab");
        }
    }
}
