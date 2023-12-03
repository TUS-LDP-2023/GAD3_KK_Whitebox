using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hopherb : MonoBehaviour
{


    public void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
