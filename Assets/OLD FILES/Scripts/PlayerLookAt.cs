using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    public Vector3 offset;
    public Transform cam;
    public StarterAssetsInputs inputs;
    void FixedUpdate()
    {
        int layerMask = 1 << 7;

        RaycastHit eyes;

        if (Physics.Raycast(transform.position + offset, cam.forward, out eyes, 10, layerMask))
        {
            if(inputs.interact == true)
            {
                inputs.interact = false;
            }
            Debug.DrawRay(transform.position + offset, cam.TransformDirection(Vector3.forward) * eyes.distance, Color.yellow);
        } else
        {
            if (inputs.interact == true)
            {
                inputs.interact = false;
            }
            Debug.DrawRay(transform.position + offset, cam.TransformDirection(Vector3.forward) * 10, Color.white);
        }
    }
}
