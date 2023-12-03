using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnArea : MonoBehaviour
{
    public PlayerCheck playerCheck;
    public StarterAssetsInputs _inputs;
    public PlayerLookAt lookAt;
    public ThrowPotion potionReset;
    public InventoryScript inventory;
    public GameObject player;

    private void Start()
    {
        playerCheck = GetComponentInParent<PlayerCheck>();

    }

    public void Update()
    {
        if(lookAt.inputs.interact == true && playerCheck.playerIn == true)
        {
            potionReset.totalThrows = 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        }
    }
}
