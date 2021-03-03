using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Animator animator;
    public int damage;
    private PlayerHealth playerHealth;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            rb.velocity = new Vector2(-2, -10);
            rb.isKinematic = false;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            rb.isKinematic = true;
            playerHealth.DamagePlayer(damage);
        }
        animator.SetBool("explode", true);
        Invoke("MyDestroy", 0.9f);
    }
    void MyDestroy()
    {
        Destroy(gameObject);
    }
}
