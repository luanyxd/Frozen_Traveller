using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public string achievementId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided.");
        Debug.Log(other.gameObject.tag);
        Debug.Log(other.GetType().ToString());
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString()== "UnityEngine.CapsuleCollider2D")
        {
            FindObjectOfType<GlobalAchieve>().TriggerAchievementById(achievementId);
            FindObjectOfType<AudioManager>().Play("Coin");
            Debug.Log("Destroying.");
            Destroy(gameObject);
        }
    }
}
