using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

[CreateAssetMenu(fileName = "New NPC Dialogue", menuName = "Dialogue/NPCDialogue")]
public class DialogueDisplayer : ScriptableObject
{
    public List<Dialogue> DialogueList = new List<Dialogue>();
}
[System.Serializable]
public class Dialogue
{
    public DialogueObjectCreator dialogue;
    public Dialogue(DialogueObjectCreator _dialogue)
    {
        dialogue = _dialogue;

    }
}

