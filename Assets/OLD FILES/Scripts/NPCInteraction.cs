using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public PlayerCheck playerCheck;
    public PlayerLookAt lookAt;
    public GameObject player;
    public GameObject dialogueText;
    public TMP_Text dialogue;
    public string dialogueString;
    private void Start()
    {
        playerCheck = GetComponentInParent<PlayerCheck>();
        lookAt = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLookAt>();
        dialogueText.SetActive(false);
    }

    public void Update()
    {
        if (lookAt.inputs.interact == true && playerCheck.playerIn == true)
        {
            dialogueText.SetActive(true);
            dialogue.text = dialogueString;
            Invoke(nameof(Deactivate), 5);
        }
    }

    private void Deactivate()
    {
        dialogueText.SetActive(false);
    }

}
