using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AliceScript : MonoBehaviour
{
    
    public Rigidbody2D aliceRB;
    public float currentSpeed;
    public float normalSpeed;
    public float stunDuration;
    private bool isStunned = false;
    public float input;
    public SpriteRenderer sprite;
    public Sprite jumpSprite;
    public Sprite fallSprite;
    public Sprite idleSprite;
    
    public float jumpSpeed;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPos;
    public float groundCheckCircle;

    public float jumpTime;
    public float jumpCounter;
    private bool isJumping;
    
    private Color normalColor = Color.white;
    private Color stunnedColor = Color.gray;

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
        sprite.color = normalColor;
    }

    public void ResetSpeed()
    {
        currentSpeed = normalSpeed;
    }
    //stunning section
    public void Stun()
    {
        if (!isStunned)
        {
            isStunned = true;
            currentSpeed = 0;
            sprite.color = stunnedColor;
            StartCoroutine(StunCoroutine());
        }
    }
    
    private IEnumerator StunCoroutine()
    {
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
        ResetSpeed();
        sprite.color = normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStunned) return;
        //setup for alice movement
       input = Input.GetAxisRaw("Horizontal");
    
       aliceRB.velocity = new Vector2(input * currentSpeed, aliceRB.velocity.y);
       
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
       //changing sprites
       if (aliceRB.velocity.y > 0)
       {
           sprite.sprite = jumpSprite;
       }
       else if (aliceRB.velocity.y < 0)
       {
           sprite.sprite = fallSprite;
       }
       else if (isGrounded)
       {
           sprite.sprite = idleSprite;
       }
     //losing
       if (transform.position.y< -50)
       {
           SceneManager.LoadScene("You Lose");
       }
    }
    
}
