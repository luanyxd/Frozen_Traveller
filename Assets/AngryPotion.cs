using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPotion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Debug.Log("Meet player, bottle!");
            //change the number of coins
            FindObjectOfType<AudioManager>().Play("Coin");
            FindObjectOfType<ChangeModeButton>().increaseBottleAmount();
            Destroy(gameObject);
        }
    }
}
