using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{

    public Transform target;

    public void Update()
    {
        transform.LookAt(target);
    }

}
