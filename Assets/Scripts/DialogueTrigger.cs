using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        if (GameObject.Find("player").GetComponent<playercontroller>().isActiveAndEnabled)
        {
            FindObjectOfType<playercontroller>().setIdle();
        }
            
        else
        {
            FindObjectOfType<playercontroller_2>().setIdle();
        }
            
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
