using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAt : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);

    }
}
