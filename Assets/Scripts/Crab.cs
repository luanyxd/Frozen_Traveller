using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int damage;
    public bool hurt;
    private PlayerHealth playerHealth;
    public Transform leftpoint, rightpoint;
    private bool Faceleft =false;
    public float speed;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        transform.DetachChildren();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.DamagePlayer(damage);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "snowball(Clone)")
        {
            Destroy(other.gameObject);
            health -= 1;
            changeState();
            Invoke("changeState", 0.4f);
        }
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    void changeState()
    {
        hurt = !hurt;
        animator.SetBool("hurt", hurt);
    }
    
    void Movement()
    {
        if (hurt)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (Faceleft)
        {
          
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftpoint.position.x)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
                Faceleft = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightpoint.position.x)
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                Faceleft = true;
            }
        }
    }
}
