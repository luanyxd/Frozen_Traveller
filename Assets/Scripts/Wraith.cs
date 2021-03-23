using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int damage;
    public bool hurt;
    public bool attack;
    private PlayerHealth playerHealth;
    public Transform toppoint, downpoint;
    private bool goingUp = false;
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
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-0.75f, 0.75f, 1);
            }
            else
            {
                transform.localScale = new Vector3(0.75f, 0.75f, 1);
            }
            attackState();
            Invoke("attackState", 0.4f);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "snowball(Clone)")
        {
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-0.75f, 0.75f, 1);
            }
            else
            {
                transform.localScale = new Vector3(0.75f, 0.75f, 1);
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
        if (hurt || attack)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (goingUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            transform.localScale = new Vector3(-0.75f, 0.75f, 1);
            if (transform.position.y > toppoint.position.y)
            {
                goingUp = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            transform.localScale = new Vector3(-0.75f, 0.75f, 1);
            if (transform.position.y < downpoint.position.y)
            {
                goingUp = true;
            }
        }
    }
    void MyDestroy()
    {
        Destroy(gameObject);
    }
}
