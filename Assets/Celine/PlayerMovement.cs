using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6;
    public float jumpForce = 500;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    
    private Rigidbody2D rigidBody2D;
    public bool grounded = true;
    private float groundRadius = 0.2f;
    private float moveHorizontal;
    private float tempMove;

    void Start ()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Check if player touches a ground object
        if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        moveHorizontal = (Input.GetAxis("Horizontal"));

        if (grounded)
        {
            rigidBody2D.velocity = new Vector2(moveHorizontal * speed, rigidBody2D.velocity.y);
        }
        else
        {
            // If player turns mid-jump
            if (tempMove > 0.01 && moveHorizontal < -0.01)
            {
                rigidBody2D.velocity = new Vector2(moveHorizontal * speed * 0.3f, rigidBody2D.velocity.y);
            }
            else if (tempMove < -0.01 && moveHorizontal > 0.01)
            {
                rigidBody2D.velocity = new Vector2(moveHorizontal * speed * 0.3f, rigidBody2D.velocity.y);
            }
        }

        // If player is grounded, player can jump
        if (grounded && (Input.GetAxis("A_Button") >= 0.01))
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            tempMove = moveHorizontal;
        }
    }

    private void Update()
    {
        
    }
}
