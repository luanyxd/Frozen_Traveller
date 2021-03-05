using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell : MonoBehaviour
{
    //public int damage;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CompleteLevel(false);
        }
    }
}
