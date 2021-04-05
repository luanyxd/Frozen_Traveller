using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_in : MonoBehaviour
{
    private bool hasEntered;
    private Vector3 outPosition;

    void Start()
    {
        hasEntered = false;
        outPosition = new Vector3(-58.51f, -3.82f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasEntered && other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            hasEntered = true;
            FindObjectOfType<Door_out>().inPosition = FindObjectOfType<playercontroller_2>().getPosition();
            StartCoroutine(JumpToBonusLevel());
        }
    }

    IEnumerator JumpToBonusLevel()
    {
        // play animation
        FindObjectOfType<LevelChanger>().transition.SetBool("Close", true);

        // wait animation complete
        yield return new WaitForSeconds(FindObjectOfType<LevelChanger>().transitionTime);

        FindObjectOfType<playercontroller_2>().setPosition(outPosition);

        FindObjectOfType<LevelChanger>().transition.SetBool("Close", false);
    }
}
