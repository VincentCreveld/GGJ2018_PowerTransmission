using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 6;
    public float jumpForce = 700;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    
    private Rigidbody2D rigidBody2D;
    public bool grounded = true;
    private float groundRadius = 0.2f;
    private float move;

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

        move = (Input.GetAxis("Horizontal"));
        rigidBody2D.velocity = new Vector2(move * speed, rigidBody2D.velocity.y);
	}

    private void Update()
    {
        // If player is grounded, player can jump
        if (grounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))) {
            rigidBody2D.AddForce(new Vector2(0, jumpForce));
        }
    }
}
