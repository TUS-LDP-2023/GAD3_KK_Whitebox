using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows;
using StarterAssets;

public class DialogueUIDisplay : MonoBehaviour
{
    [Header("Inventory Slot Display")]
    public TMP_Text text;
    public DialogueDisplayer dialogue;
    public int diaPos = 0;
    [Space]
    public StarterAssetsInputs inputs;
    public PlayerCheck playerCheck;
    public PlayerLookAt lookAt;
    public GameObject player;
    public GameObject dialogueText;
    public bool firstInteraction = true;

    private void Start()
    {
        playerCheck = GetComponentInParent<PlayerCheck>();
        lookAt = player.GetComponent<PlayerLookAt>();
        dialogueText.SetActive(false);
    }
    private void Update()
    {
        if (lookAt.inputs.interact == true && playerCheck.playerIn == true)
        {
            if(firstInteraction)
            {
             firstInteraction = false;
            }
            else
            {
            diaPos++;
            }

            dialogueText.SetActive(true);    

            if (diaPos > dialogue.DialogueList.Count - 1)
            {
                diaPos = 0;
                dialogueText.SetActive(false);
                firstInteraction = true;

            }

            Debug.Log("Player in Range and Interacting");
        }

        if (dialogue.DialogueList.Count >= 0)
        {

            text.enabled = true;
            Dialogue slotDis = dialogue.DialogueList[diaPos];
            text.text = slotDis.dialogue.dialogue;

        }
        else if (diaPos >= dialogue.DialogueList.Count)
        {
            diaPos = 0;
            dialogueText.SetActive(false);
        }
    }



}
