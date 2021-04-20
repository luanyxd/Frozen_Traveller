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
    private bool hasEnd;

    private bool isCommunicating;

    private void Start()
    {
        hint.SetActive(true);
        isCommunicating = false;
        hasEnd = false;
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
        if (!hasEnd)
        {
            if (winConditions <= 0)
            {
                hasEnd = true;
                gameManager.CompleteLevel(true);
                FindObjectOfType<GlobalAchieve>().TriggerAchievementById(levelCompleteAchievementName);
            }
            else if (!isCommunicating)
            {
                isCommunicating = true;
                StartCoroutine(ShowHintCoroutine());
            }
        }
    }

    private IEnumerator ShowHintCoroutine()
    {
        dialogueTrigger.TriggerDialogue();
        yield return new WaitForSeconds(10f);
        isCommunicating = false;

    }
}
