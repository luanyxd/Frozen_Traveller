using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int damage;
    public bool hurt;
    public bool attack;
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
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                //Debug.Log(transform.position.x + 0.05f);
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }
            if (!attack)
            {
                playerHealth.DamagePlayer(damage);
                attackState();
                Invoke("attackState", 0.4f);
            }            
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

                hurtState();
                Invoke("hurtState", 0.4f);
            }
        }

    }
    void attackState()
    {
        attack = !attack;
        animator.SetBool("attack", attack);
    }
    void hurtState()
    {
        hurt = !hurt;
        animator.SetBool("hurt", hurt);
    }

    void Movement()
    {
        if (hurt||attack)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (Faceleft)
        {

            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            if (transform.position.x < leftpoint.position.x)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
                Faceleft = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
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
