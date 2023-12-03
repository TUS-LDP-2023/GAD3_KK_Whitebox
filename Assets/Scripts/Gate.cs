using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject key;
    public bool keyCollected;
    public StarterAssetsInputs inputs;

    public void Update()
    {
        if (key == null)
        {
            keyCollected = true;
        }
        if (inputs.interact == true && keyCollected == true)
        {
            inputs.interact = false;
            Destroy(gameObject);
        }
    }
}
