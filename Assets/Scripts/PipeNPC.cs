using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNPC : MonoBehaviour
{

    public int communicating; // 1 - default, no communication; 2 - is communicating; 3 - has communicated
    public GameObject movingCanvas;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("player");
        movingCanvas = GameObject.Find("Canvas-Moving and Action");
        communicating = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (communicating == 1 && Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 1)
        {
            // start conversation
            Debug.Log("start communicating");

            // disable moving and jumping UI
            movingCanvas.SetActive(false);
            FindObjectOfType<playercontroller>().joystick.SnapX = false;

            // trigger conversation
            communicating = 2;
            StopAllCoroutines();
            playercontroller.enableMoving = false;
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        }
    }
}
