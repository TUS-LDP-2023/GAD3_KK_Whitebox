using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopEffector : MonoBehaviour
{
    public FirstPersonController FPSController;

    private void Start()
    {
        FPSController = FindObjectOfType<FirstPersonController>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            FPSController.JumpHeight = 7.2f;
            Debug.Log("PlayerInEffector");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FPSController.JumpHeight = 2.4f;
        }
    }

}
