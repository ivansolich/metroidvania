using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpHeight;
    float velX, velY;
    private Rigidbody2D rb;
    public Transform groundCheck;
    public bool Grounded;
    public float JumpForce;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,Vector3.down * 0.4f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down,  0.4f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }
        if (Grounded)
        {
            anim.SetBool("jump",false);
        }
        else
        {
            anim.SetBool("jump",true);
        }
        
        FlipCharacter();
        Attack();
    }

    public void FixedUpdate()
    {
        Movement();
        
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack",false);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce);
    }

    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);

        if (rb.velocity.x != 0)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
    }

    public void FlipCharacter()
    {
        if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if((rb.velocity.x < 0))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }  
    }
}
