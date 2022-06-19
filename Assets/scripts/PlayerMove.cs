using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;

    public float jumpSpeed = 3;
    private Animator animator;
    private Rigidbody2D rb2D;
    private float Horizontal;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");



        if (Horizontal < 0.0f) transform.localScale = new Vector3(-0.7f, 0.7f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);


        if (Input.GetKey("w") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }


        if (CheckGround.isGrounded==false)
        {
            Debug.Log("hola");
            animator.SetBool("Jump", true);
            animator.SetBool("running", false);

        }
        if (CheckGround.isGrounded==true)
        {
            animator.SetBool("Jump", false);
        }


        
        animator.SetBool("running", Horizontal != 0.0f);

      
    }

   

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(Horizontal, rb2D.velocity.y);   
    }

}
