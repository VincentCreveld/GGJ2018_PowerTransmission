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
    private bool grounded = true;
    private float groundRadius = 0.2f;
    private float gravityScale;

    private float moveVertical;
    private float moveHorizontal;
    private float tempMove;
    private bool climbable = false;

    void Start ()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        gravityScale = rigidBody2D.gravityScale;
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

        // MOVING HORIZONTALLY
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

        // CLIMBING
        moveVertical = (Input.GetAxis("Vertical"));
        if (climbable)
        {
            rigidBody2D.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        }

        // JUMPING
        if (grounded && (Input.GetAxis("A_Button") >= 0.01))
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            tempMove = moveHorizontal;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stairs")
        {
            climbable = true;
            rigidBody2D.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Stairs")
        {
            climbable = false;
            rigidBody2D.gravityScale = gravityScale;
        }
    }
}
