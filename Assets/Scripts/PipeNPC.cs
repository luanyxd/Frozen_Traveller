using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNPC : MonoBehaviour
{

    public int communicating; // 1 - default, no communication; 2 - is communicating; 3 - has communicated
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("player");
        communicating = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (communicating == 1 && Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 1)
        {
            // start conversation

            // TODO: disable moving and jumping UI

            // trigger conversation
            communicating = 2;
            FindObjectOfType<playercontroller>().enableMoving = false;
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        }
    }
}
