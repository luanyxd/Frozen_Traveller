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
    private bool Faceleft = false;
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
            if(other.gameObject.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            }
            else
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
            Destroy(other.gameObject);
            health -= 1;
            if (health == 0)
            {
                animator.SetBool("die", true);
                Invoke("MyDestroy", 0.4f);
            }
            else
            {

                changeState();
                Invoke("changeState", 0.4f);
            }
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
    void MyDestroy()
    {
        Destroy(gameObject);
    }
}
