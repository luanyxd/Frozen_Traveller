using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage;
    private PlayerHealth playerHealth;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -1f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString()== "UnityEngine.PolygonCollider2D")
        {
            playerHealth.DamagePlayer(damage);
            FindObjectOfType<AudioManager>().Play("Hit");
        }
    }
}
