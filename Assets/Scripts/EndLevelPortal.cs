using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelPortal : MonoBehaviour
{
    public GameManager gameManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Meet Portal");
        gameManager.CompleteLevel();
        GlobalAchieve.ach02Trigger = true;
    }
}
