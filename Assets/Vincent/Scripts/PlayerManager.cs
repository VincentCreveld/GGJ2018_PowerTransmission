using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	//Enter button functionality
	public TransmissionEvent X_ButtonSwap;
	//Enter button functionality
	public TransmissionEvent Y_ButtonSwap;
	//Enter button functionality
	public TransmissionEvent A_ButtonSwap;
	//Enter button functionality
	public TransmissionEvent B_ButtonSwap;

	public bool a_isEnabled;
	public bool b_isEnabled;
	public bool x_isEnabled;
	public bool y_isEnabled;

	public bool a_active;
	public bool b_active;
	public bool x_active;
	public bool y_active;
	public bool trig_active;

	private SwapManager swapManager;
	public ControllerInput connectedController;

	private GameObject A_UI;
	private GameObject B_UI;
	private GameObject X_UI;
	private GameObject Y_UI;

	public BlockSize blockSize;


	#region Variabele Celine player manager
	public float speed = 6;
	public float jumpForce = 8;

	public Transform groundCheck;
	private LayerMask whatIsGround;

	private Rigidbody2D rigidBody2D;
	private bool grounded = true;
	private float groundRadius = 0.2f;
	private float gravityScale;

	private float moveVertical;
	private float moveHorizontal;
	private float tempMove;
	private bool climbable = false;
	#endregion

	public void Initialize() {
		swapManager = SwapManager.instance;

		SubscribeFunctionality();

		groundCheck = transform.GetChild(0);
		whatIsGround = LayerMask.NameToLayer("TransparentFX");

		rigidBody2D = GetComponent<Rigidbody2D>();
		gravityScale = rigidBody2D.gravityScale;

		EventManager.instance.playerDeath += Die;

		A_UI = GetComponentInChildren<Canvas>().transform.GetChild(0).gameObject;
		B_UI = GetComponentInChildren<Canvas>().transform.GetChild(1).gameObject;
		X_UI = GetComponentInChildren<Canvas>().transform.GetChild(2).gameObject;
		Y_UI = GetComponentInChildren<Canvas>().transform.GetChild(3).gameObject;

		A_UI.SetActive(a_isEnabled);
		B_UI.SetActive(b_isEnabled);
		X_UI.SetActive(x_isEnabled);
		Y_UI.SetActive(y_isEnabled);
	}

	//input is handled here.
	private void FixedUpdate() {
		if(trig_active) {
			if(a_active && a_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "A Trigger!");
				//Should be empty because the jump ability can't be transmitted.
			}
			if(b_active && b_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "B Trigger!");
				B_SwapCall();
			}
			if(x_active && x_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "X Trigger!");
				X_SwapCall();
				Y_SwapCall();
			}
			if(y_active && y_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "Y Trigger!");
				Y_SwapCall();
				X_SwapCall();
			}
		}
		else {
			if(a_active) {
				Debug.Log(connectedController.GetControllerName() + "A");
				Jump();
			}
			if(b_active) {
				Debug.Log(connectedController.GetControllerName() + "B");
			}
			if(x_active) {
				Shrink();
				Debug.Log(connectedController.GetControllerName() + "X");
			}
			if(y_active) {
				Grow();
				Debug.Log(connectedController.GetControllerName() + "Y");
			}
		}
		
		#region Physics Celine
		

		// MOVING HORIZONTALLY
		moveHorizontal = (Input.GetAxis(connectedController.GetHorizontal()));
		if(grounded) {
			rigidBody2D.velocity = new Vector2(moveHorizontal * speed, rigidBody2D.velocity.y);
		}
		else {
			// If player turns mid-jump
			if(tempMove > 0.01 && moveHorizontal < -0.01) {
				rigidBody2D.velocity = new Vector2(moveHorizontal * speed * 0.3f, rigidBody2D.velocity.y);
			}
			else if(tempMove < -0.01 && moveHorizontal > 0.01) {
				rigidBody2D.velocity = new Vector2(moveHorizontal * speed * 0.3f, rigidBody2D.velocity.y);
			}
		}

		// CLIMBING
		moveVertical = (Input.GetAxis(connectedController.GetVertical()));
		if(climbable) {
			if(!grounded)
				rigidBody2D.velocity = new Vector2(moveHorizontal * speed / 3, moveVertical * speed);
			else
				rigidBody2D.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
		}

	}

	private void Update() {
		// Check if player touches a ground object
		if(Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround)) {
			grounded = true;
		}
		else {
			grounded = false;
		}

		trig_active = connectedController.Trig_CheckInput();
		a_active = connectedController.A_CheckInput();
		b_active = connectedController.B_CheckInput();
		x_active = connectedController.X_CheckInput();
		y_active = connectedController.Y_CheckInput();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Stairs") {
			climbable = true;
			rigidBody2D.gravityScale = 0;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if(collision.tag == "Stairs") {
			climbable = false;
			rigidBody2D.gravityScale = gravityScale;
		}
	}

	

	private void Jump() {
		if(grounded) {
			rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
			tempMove = moveHorizontal;
		}
	}

	private void Shrink() {
		Debug.Log("Shrink!");
		switch(blockSize) {
			case BlockSize.small:
				blockSize = BlockSize.small;
				break;
			case BlockSize.medium:
				blockSize = BlockSize.small;
				break;
			case BlockSize.large:
				blockSize = BlockSize.medium;
				break;
		}
	}
	private void Grow() {
		Debug.Log("Grow!");
		switch(blockSize) {
			case BlockSize.small:
				blockSize = BlockSize.medium;
				break;
			case BlockSize.medium:
				blockSize = BlockSize.large;
				break;
			case BlockSize.large:
				blockSize = BlockSize.large;
				break;
		}
	}
	#endregion

	private void SubscribeFunctionality() {
		swapManager.A_ButtonTransmission += A_SwapBool;
		swapManager.B_ButtonTransmission += B_SwapBool;
		swapManager.X_ButtonTransmission += X_SwapBool;
		swapManager.Y_ButtonTransmission += Y_SwapBool;
	}

	private void Die() {
		//Everything onDeath!
	}

	#region Bool swap functionality
	public void A_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping A bool!");
		a_isEnabled = !a_isEnabled;
		A_UI.SetActive(a_isEnabled);
	}
	public void B_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping B bool!");
		b_isEnabled = !b_isEnabled;
		B_UI.SetActive(b_isEnabled);
	}
	public void X_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping X bool!");
		x_isEnabled = !x_isEnabled;
		X_UI.SetActive(x_isEnabled);
	}
	public void Y_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping Y bool!");
		y_isEnabled = !y_isEnabled;
		Y_UI.SetActive(y_isEnabled);
	}
	#endregion

	#region Swap Calls
	//These functions are called with input to notify the SwapManager to switch over the controls.
	public void A_SwapCall() {
		A_ButtonSwap();
	}
	public void B_SwapCall() {
		B_ButtonSwap();
	}
	public void X_SwapCall() {
		X_ButtonSwap();
	}
	public void Y_SwapCall() {
		Y_ButtonSwap();
	}
#endregion
}
