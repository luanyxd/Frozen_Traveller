using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_out : MonoBehaviour
{
    public Vector3 inPosition;
    public bool inBonusLevel;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (inBonusLevel && other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            inBonusLevel = false;
            StartCoroutine(JumpBackToNormalLevel());
        }
    }

    IEnumerator JumpBackToNormalLevel()
    {
        // play animation
        FindObjectOfType<LevelChanger>().transition.SetBool("Close", true);

        // wait animation complete
        yield return new WaitForSeconds(FindObjectOfType<LevelChanger>().transitionTime);

        FindObjectOfType<playercontroller_2>().setPosition(inPosition);

        FindObjectOfType<LevelChanger>().transition.SetBool("Close", false);
    }
}
