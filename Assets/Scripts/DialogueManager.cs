﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject gameComplete;

    public Animator animator;

    private Queue<Dialogue.nameSentence> nameSentences; // FIFO Collection
    private string npcName;

    // Start is called before the first frame update
    void Start()
    {
        nameSentences = new Queue<Dialogue.nameSentence>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start Dialogue!");

        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.npcName;
        npcName = dialogue.npcName;
        nameSentences.Clear();
        foreach (Dialogue.nameSentence nameSentence in dialogue.nameSentences)
        {
            nameSentences.Enqueue(nameSentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log("Display next sentence!");

        if (nameSentences.Count == 0)
        {
            EndDialogue();
            if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                Debug.Log("DISPLAY GAMECOMPLETE");
                gameComplete.SetActive(true);
            }
            return;
        }

        Dialogue.nameSentence nameSentence = nameSentences.Dequeue();
        string sentence = nameSentence.sentence;
        if (nameSentence.isNPC)
        {
            nameText.text = npcName;
        } else
        {
            nameText.text = "Snowman";
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        if (GameObject.Find("player").GetComponent<playercontroller>().isActiveAndEnabled)
            playercontroller.enableMoving = true;
        else
            playercontroller_2.enableMoving = true;
        
        Time.timeScale = 1f;

        // TODO: display joystick

        //FindObjectOfType<PipeNPC>().movingCanvas.SetActive(true);
        Debug.Log("calling EndDialog");
    }
}
