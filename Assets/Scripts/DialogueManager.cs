using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

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
        if (nameSentences.Count == 0)
        {
            EndDialogue();
            Debug.Log("calling EndDialog ==================================================");
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
        //playercontroller.enableMoving = true;
        playercontroller_2.enableMoving = true;
        FindObjectOfType<playercontroller_2>().enabled = true;
        //Time.timeScale = 1f;

        // TODO: display joystick

        //FindObjectOfType<PipeNPC>().movingCanvas.SetActive(true);
        Debug.Log("calling EndDialog");
    }
}
