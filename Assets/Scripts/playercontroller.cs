using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float doubleJumpSpeed;

    public static bool enableMoving;

    public Joystick joystick;

    private Rigidbody2D rb2d;
    private Animator anim;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool canDoubleJump;

    //private PlayerInputaction controls;
    private Vector2 move;
    //void Awake()
    //{
    //    controls = new PlayerInputaction();
        
    //    controls.GamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
    //    controls.GamePlay.Move.canceled += ctx => move = Vector2.zero;
    //    controls.GamePlay.Attack.started += ctx => Attack();
    //    controls.GamePlay.Jump.started += ctx => Jump();
        
        

    //}
    //void OnEnable()
    //{
    //    controls.GamePlay.Enable();
    //}

    //void OnDisable()
    //{
    //    controls.GamePlay.Disable();
    //}



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        enableMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
        //Jump();
        CheckGrounded();
       // SwitchAnimation();
        //Attack();

    }
    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        //Debug.Log(isGround);
    }
    void Run()
    {
        if (enableMoving)
        {

            float moveDir;

            // Add joystick, make the movement not that sensitive
            if (joystick.Horizontal >= .2f)
            {
                moveDir = joystick.Horizontal;
            } else if (joystick.Horizontal <= .2f)
            {
                moveDir = -joystick.Horizontal;
            } else
            {
                moveDir = 0f;
            }

            //float moveDir = Input.GetAxis("Horizontal");
            moveDir = joystick.Horizontal;
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
      
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                rb2d.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
            }
            else
            {
                if(canDoubleJump)
                {
                    Vector2 doubleJumpVel = new Vector2(0.0f,doubleJumpSpeed);
                    rb2d.velocity = Vector2.up * doubleJumpVel;
                    canDoubleJump = false;
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
    void Attack()
    {
       // if (Input.GetButtonDown("Attack"))
        {
            anim.SetTrigger("Attack");
        }
       // anim.SetBool("idle", true);
    }
}
