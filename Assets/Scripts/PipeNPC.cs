using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNPC : MonoBehaviour
{

    public int communicating; // 1 - default, no communication; 2 - is communicating; 3 - has communicated
    public DialogueTrigger dialogueTrigger;

    private void Start()
    {
        communicating = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger!");
        if (communicating == 1)
        {
            //Time.timeScale = 0f;
            communicating = 2;
            //StopAllCoroutines();
            playercontroller.enableMoving = false;
            dialogueTrigger.TriggerDialogue();
            communicating = 3;
            if (FindObjectOfType<EndTrigger>() != null)
            {
                FindObjectOfType<EndTrigger>().winConditions--;
            }
        }
    }
}
