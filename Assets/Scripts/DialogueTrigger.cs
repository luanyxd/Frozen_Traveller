using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<playercontroller_2>().setIdle();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
