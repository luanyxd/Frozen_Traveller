using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject hint;
    public DialogueTrigger dialogueTrigger;
    public int winConditions;
    public string levelCompleteAchievementName;

    private bool isCommunicating;

    private void Start()
    {
        hint.SetActive(true);
        isCommunicating = false;
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
            FindObjectOfType<GlobalAchieve>().TriggerAchievementById(levelCompleteAchievementName);
        } else if (!isCommunicating)
        {
            isCommunicating = true;
            StartCoroutine(ShowHintCoroutine());
        }
    }

    private IEnumerator ShowHintCoroutine()
    {
        dialogueTrigger.TriggerDialogue();
        yield return new WaitForSeconds(10f);
        isCommunicating = false;

    }
}
