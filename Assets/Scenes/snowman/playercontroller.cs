using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    private Rigidbody2D rb2d;
    private Animator anim;
    private BoxCollider2D myFeet;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
        Jump();
        CheckGrounded();
    }
    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log(isGround);
    }
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * speed, rb2d.velocity.y);
        rb2d.velocity = playerVel;
        bool playerHasXSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
        anim.SetBool("Run", playerHasXSpeed);

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
            }
        }
    }
}
