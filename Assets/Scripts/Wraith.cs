using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Wraith : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int damage;
    public bool hurt;
    public bool attack;
    private PlayerHealth playerHealth;
    public AIPath aiPath;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Debug.Log(rb.velocity.x);
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
            FindObjectOfType<AudioManager>().Play("EnemyHit");
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

        if (aiPath.desiredVelocity.x<0)
        {
            transform.localScale = new Vector3(-0.75f, 0.75f, 1);
        }
        else
        {
            transform.localScale = new Vector3(0.75f, 0.75f, 1);
        }
    }
    void MyDestroy()
    {
        Destroy(gameObject);
    }
}
