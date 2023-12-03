using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Option", menuName = "Dialogue")]
public class DialogueObjectCreator : ScriptableObject
{
    [TextArea(5, 20)]
    public string dialogue;
}
