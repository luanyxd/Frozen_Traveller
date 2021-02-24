using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Entered a collectSquare!");
        GlobalAchieve.ach01Count += 1;
        Debug.Log("count: " + GlobalAchieve.ach01Count);
        //collectSound.Play();
        Destroy(gameObject);
    }
}
