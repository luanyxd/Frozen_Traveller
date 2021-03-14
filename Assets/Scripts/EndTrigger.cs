using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject hint;
    public DialogueTrigger dialogueTrigger;
    public int winConditions;

    private void Start()
    {
        hint.SetActive(true);
    }
    private void Update()
    {
        if (winConditions == 0)
        {
            hint.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (winConditions <= 0)
        {
            gameManager.CompleteLevel(true);
            GlobalAchieve.ach02Trigger = true;
        } else
        {
            StartCoroutine(ShowHintCoroutine());
        }
    }

    private IEnumerator ShowHintCoroutine()
    {
        dialogueTrigger.TriggerDialogue();
        yield return new WaitForSeconds(10f);
    }
}
