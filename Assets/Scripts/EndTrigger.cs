using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject hint;
    public bool missonComplete;

    private void Start()
    {
        missonComplete = false;
        hint.SetActive(true);
    }
    private void Update()
    {
        if (missonComplete)
        {
            hint.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (missonComplete)
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
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        yield return new WaitForSeconds(10f);
    }
}
