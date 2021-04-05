using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int Speed;
    private PlayerHealth playerHealth;
    public int score;
    public Door_out door_out;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            door_out.inBonusLevel = true;
            rb.velocity = new Vector2(0, 0-Speed);
            rb.isKinematic = false;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = true;
            //playerHealth.DamagePlayer(damage);
        }
        rb.velocity = new Vector2(0, 0);
        Destroy(gameObject);
    }
    
}
