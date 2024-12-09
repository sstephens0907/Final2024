using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AliceScript : MonoBehaviour
{
    
    public Rigidbody2D aliceRB;
    public float Speed;
    public float input;
    public SpriteRenderer sprite;
    
    public float jumpSpeed;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPos;
    public float groundCheckCircle;

    public float jumpTime;
    public float jumpCounter;
    private bool isJumping;

    // Update is called once per frame
    void Update()
    {
        //setup for alice movement
       input = Input.GetAxisRaw("Horizontal");
    
       aliceRB.velocity = new Vector2(input * Speed, aliceRB.velocity.y);
       
       //alice direction
       if (input < 0)
       {
           sprite.flipX = false;
       }
       else if (input > 0)
       {
           sprite.flipX = true;
       }
       
       //jumping section
       //is alice on the ground
       isGrounded = Physics2D.OverlapCircle(feetPos.position, groundCheckCircle, groundLayer);
       
       if (isGrounded == true && Input.GetButtonDown("Jump"))
       {
           isJumping = true;
           jumpCounter = jumpTime;
           aliceRB.velocity = Vector2.up * jumpSpeed;
       }

       if (Input.GetButton("Jump") && isJumping == true)
       {
           if (jumpTime > 0)
           {
               aliceRB.velocity = Vector2.up * jumpSpeed;
               jumpCounter -= Time.deltaTime;
           }
           else
           {
               isJumping = false;
           }
       }

       if (Input.GetButtonUp("Jump"))
       {
           isJumping = false;
       }
     
       if (transform.position.y< -50)
       {
           SceneManager.LoadScene("You Lose");
       }
    }
    
}
