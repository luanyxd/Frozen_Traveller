using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player!");
            Debug.Log(other.GetType().ToString());
        }
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
