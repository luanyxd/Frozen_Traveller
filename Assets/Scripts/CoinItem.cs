using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{

    public playercontroller player;

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
            //change the number of coins
            FindObjectOfType<CoinCollectedDisplayer>().IncreaseCoin();
            FindObjectOfType<GlobalAchieve>().increaseCollectionAchievementById("level1_coin");
            FindObjectOfType<AudioManager>().Play("Coin");
            FindObjectOfType<EndTrigger>().winConditions--;
            Destroy(gameObject);

            //
            //player.increaseCoin();

        }
    }
}
