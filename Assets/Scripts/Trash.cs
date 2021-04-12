using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    //public playercontroller player;
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
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString()== "UnityEngine.CapsuleCollider2D")
        {
            //change the number of trash
            FindObjectOfType<GlobalAchieve>().increaseCollectionAchievementById(achievementId);
            //FindObjectOfType<AudioManager>().Play("Coin");
            //FindObjectOfType<EndTrigger>().winConditions--;
            FindObjectOfType<CoinCollectedDisplayer>().IncreaseNum(2);
            //FindObjectOfType<GlobalAchieve>().increaseCollectionAchievementById(achievementId);
            FindObjectOfType<AudioManager>().Play("Coin");
            Destroy(gameObject);

            //
            //player.increaseCoin();

        }
    }
}
