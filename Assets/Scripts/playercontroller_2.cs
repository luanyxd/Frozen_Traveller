using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller_2 : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float doubleJumpSpeed;

    // control moving ability
    public static bool enableMoving;

    /*
    // joystick
    public Joystick joystick;
    */

    // change mode button
    public bool isNormal;
    public bool canAngry;
    public int angryDuration;

    // clock
    public GameObject timeDisplayer;
    public Clock countdownClock;
    public Animator clockAnim;

    // health bar
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // coin amount displayer
    public CoinCollectedDisplayer coinCollectedDisplayer;


    private Rigidbody2D rb2d;
    private Animator anim;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool isMoving;
    private bool canDoubleJump;


    private Vector2 move;
    public Snowballhit snowballhit;
    //public Snowballhit_angry snowballhit_angry;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();

        enableMoving = true;

        // currentHealth = maxHealth;
        //healthBar.SetMaximum(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
        Jump();
        CheckGrounded();
        // SwitchAnimation();
        Attack();
        stepSound();
        StartCoroutine(BecomeAngryCoroutine());

        //Debug.Log(rb2d.velocity.x);
    }
    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) || myFeet.IsTouchingLayers(LayerMask.GetMask("Movingplatform")) || myFeet.IsTouchingLayers(LayerMask.GetMask("DestructibleLayer"));
        // Debug.Log(isGround);
    }
    void Run()
    {

        if (enableMoving)
        {
            float moveDir = Input.GetAxis("Horizontal");
            //moveDir = joystick.Horizontal;
            Vector2 playerVel = new Vector2(moveDir * speed, rb2d.velocity.y);
            //Vector2 playerVel = new Vector2(move.x * speed, rb2d.velocity.y);
            rb2d.velocity = playerVel;
            bool playerHasXSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
            anim.SetBool("Run", playerHasXSpeed);
        }

    }
    void Flip()
    {
        bool playerHasXSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
        if (playerHasXSpeed)
        {
            if (rb2d.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (rb2d.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
        if (isGround)
        {
            Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
            rb2d.velocity = Vector2.up * jumpVel;
            canDoubleJump = true;
            FindObjectOfType<AudioManager>().Play("Jump");
        }
        else
        {
            if (canDoubleJump)
            {

                if (canDoubleJump)
                {
                    Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpSpeed);
                    rb2d.velocity = Vector2.up * doubleJumpVel;
                    canDoubleJump = false;
                    FindObjectOfType<AudioManager>().Play("DoubleJump");
                }


            }
        }
        }
    }
    void SwitchAnimation()
    {
        anim.SetBool("idle", false);
        if (isGround)
        {
            anim.SetBool("idle", true);
        }
    }
    public void Attack()
    {
         if (Input.GetButtonDown("Attack") && isNormal)
        {
            anim.SetBool("idle", true);
            anim.SetTrigger("Attack");
            snowballhit.Shoot();
        }
         else if (Input.GetButtonDown("Attack"))
         {
             Debug.Log("angry-Now");
             anim.SetBool("idle", true);
             anim.SetTrigger("Attack");
             snowballhit.Shoot1();
             //snowballhit_angry.Shoot_angry();
         }
        // anim.SetBool("idle", true);
    }
    /*
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    // TODO: change mode, flipping isNormal variable
     */
    public void ChangeMode()
    {
        if (canAngry && isNormal)
        {
            // TODO: change to angry mode
            isNormal = false;
        }
    }

    public IEnumerator BecomeAngryCoroutine()
    {
        if (Input.GetButtonDown("ChangeMode"))
        {
            if (isNormal)
            {
                // change to angry mode and animation
                isNormal = false;
                anim.SetBool("Angry", true);
                FindObjectOfType<AudioManager>().Play("AngryMode");


                // TODO: wait for several seconds
                clockAnim.SetBool("DisplayClock", true);
                countdownClock.clock = angryDuration;
                countdownClock.timeActive = true;
                timeDisplayer.SetActive(true);
                yield return new WaitForSeconds(angryDuration);

                // TODO: back to ordinary mode
                clockAnim.SetBool("DisplayClock", false);
                yield return new WaitForSeconds(1f);
                timeDisplayer.SetActive(false);
                countdownClock.timeActive = false;
                isNormal = true;
                anim.SetBool("Angry", false);
            }
        }
    }
    public void IncreaseCoin()
    {
        ////coinAmount++;
        //coinCollectedDisplayer.IncreaseCoin();
    }

    public void stepSound()
    {
        if(Mathf.Abs(rb2d.velocity.x) > 0.1f)
            isMoving = true;
        else
            isMoving = false;
        
        //Debug.Log(isMoving+"Moving! Playing sound.");
        if(isMoving && isGround){
            //Debug.Log("Moving! Playing sound.");
            FindObjectOfType<AudioManager>().TurnOn("PlayerStep");
        }
        else{
            //Debug.Log("NotMoving! Turning off the sound.");
            FindObjectOfType<AudioManager>().TurnOff("PlayerStep");
            //Debug.Log("The sound is playing:"+FindObjectOfType<AudioManager>().FindSound("PlayerStep").source.isPlaying);
        }
    }

    public void setIdle()
    {
        rb2d.velocity = Vector2.zero;
        enableMoving = false;
    }

    public void setDie()
    {
        Debug.Log("die!");
        enableMoving = false;
        anim.SetTrigger("Die");
    }
    
    public Vector3 getPosition()
    {
        return rb2d.transform.position;
    }

    public void setPosition(Vector3 p)
    {
        rb2d.position = p;
    }
}
