using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //rigibody zorunlu oldu.
public class PlayerController : MonoBehaviour
{
   
    Rigidbody2D rigibody;
    
    //Character
    [Tooltip("Karakterin hýzýný belirler")]
    [Range(0,20)]
    public float playerSpeed;

    //Jump
    [Tooltip("Karakterin zýplama mesafesini belirler.")]
    //Yere deðip deðmediðini kontrol etmeye yarýyor.
    public bool isGrounded; 
    Transform groundCheck;
    const float groundCheckRadius= 0.2f;
    public LayerMask groundLayer;
    //jUMPING
    public float jumpPower;
    public float doubleJumpPower;
   public bool canDoubleJump;
    //Character Rotate

    bool facingRight = true;
    void Start()
    {
        // Rigibody Settings
        rigibody = GetComponent<Rigidbody2D>();
        rigibody.gravityScale = 10;
        rigibody.freezeRotation = true;
        rigibody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        //GroundCheck Bulduk
        groundCheck = transform.Find("GroundCheck");
    }
   

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");


        flip(horizontal);
        rigibody.velocity= new Vector2(horizontal*playerSpeed,rigibody.velocity.y);  
       
        
    }

   public void jumpPlayer()
    {
        rigibody.AddForce(new Vector2(0, jumpPower));
    }

    public void DoubleJump()
    {
       rigibody.AddForce(new Vector2(0, doubleJumpPower),ForceMode2D.Impulse);
    }
    public void flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight )
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
}
