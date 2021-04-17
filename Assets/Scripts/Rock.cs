using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage;
    private PlayerHealth playerHealth;
    private bool falled = false;
    // Start is called before the first frame update
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
            if (falled) return;
            falled = true;
            rb.isKinematic = false;
            rb.gravityScale = 1;
            rb.velocity = new Vector2(-3, 0);
            rb.mass = 100;
          
        }
    }

}
