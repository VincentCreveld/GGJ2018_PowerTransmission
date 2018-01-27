using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	private const float SMALL_SIZE = .5f;
	private const float MEDIUM_SIZE = 1f;
	private const float LARGE_SIZE = 1.5f;

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

	public SwapManager swapManager;
	public ControllerInput connectedController;

	private GameObject A_UI;
	private GameObject B_UI;
	private GameObject X_UI;
	private GameObject Y_UI;
    private GameObject AGrey_UI;
    private GameObject BGrey_UI;
    private GameObject XGrey_UI;
    private GameObject YGrey_UI;

    private Animator A_Animator;
    private Animator B_Animator;
    private Animator X_Animator;
    private Animator Y_Animator;


    //The bool has to be true when an item is held for the swpmanager to function.
    public Transform pickupSlot;
	public bool hasItem = false;

	public BlockSize blockSize = BlockSize.medium;

	public Transform graphicsSlot;


	#region Variabele Celine player manager
	public float speed = 3.5f;
	public float jumpForce = 6.5f;

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
    private bool facingRight = false;
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

        AGrey_UI = GetComponentInChildren<Canvas>().transform.GetChild(4).gameObject;
        BGrey_UI = GetComponentInChildren<Canvas>().transform.GetChild(5).gameObject;
        XGrey_UI = GetComponentInChildren<Canvas>().transform.GetChild(6).gameObject;
        YGrey_UI = GetComponentInChildren<Canvas>().transform.GetChild(7).gameObject;

        A_UI.SetActive(a_isEnabled);
		B_UI.SetActive(b_isEnabled);
		X_UI.SetActive(x_isEnabled);
		Y_UI.SetActive(y_isEnabled);

        AGrey_UI.SetActive(!a_isEnabled);
        BGrey_UI.SetActive(!b_isEnabled);
        XGrey_UI.SetActive(!x_isEnabled);
        YGrey_UI.SetActive(!y_isEnabled);

        A_Animator = A_UI.GetComponent<Animator>();
        B_Animator = B_UI.GetComponent<Animator>();
        X_Animator = X_UI.GetComponent<Animator>();
        Y_Animator = Y_UI.GetComponent<Animator>();

        pickupSlot = transform.GetChild(2);

		graphicsSlot = transform.GetChild(3);
	}

	//input is handled here.
	private void FixedUpdate() {
		if(trig_active) {
			if(a_active && a_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "A Trigger!");
                
				//Should be empty because the jump ability can't be transmitted.
			}
		}
		else {
			if(a_active && a_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "A");
				Jump();
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

		if(moveHorizontal < -.19) {
			
			if(graphicsSlot.localScale.x > 0) {

				graphicsSlot.localScale = new Vector3(-graphicsSlot.localScale.x, graphicsSlot.localScale.y, graphicsSlot.localScale.z);


				pickupSlot.localPosition = new Vector3(-pickupSlot.localPosition.x, pickupSlot.localPosition.y, pickupSlot.localPosition.z);
			}
		}
		if (moveHorizontal > .19)
        {
			
			if(graphicsSlot.localScale.x < 0) {

				graphicsSlot.localScale = new Vector3(-graphicsSlot.localScale.x, graphicsSlot.localScale.y, graphicsSlot.localScale.z);


				pickupSlot.localPosition = new Vector3(-pickupSlot.localPosition.x, pickupSlot.localPosition.y, pickupSlot.localPosition.z);
			}
        }

		/*
		if(facingRight) {
			graphicsSlot.localScale = new Vector3(1, graphicsSlot.localScale.y, graphicsSlot.localScale.z);
		}
		else if(!facingRight) {
			graphicsSlot.localScale = new Vector3(-1, graphicsSlot.localScale.y, graphicsSlot.localScale.z);
		}
		*/


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

		if(trig_active) {
            A_Animator.SetBool("leftTrigger", true);
            B_Animator.SetBool("leftTrigger", true);
            X_Animator.SetBool("leftTrigger", true);
            Y_Animator.SetBool("leftTrigger", true);
            if (b_active && b_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "B Trigger!");
				B_SwapCall();
				Y_SwapCall();

            }
            if (x_active && x_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "X Trigger!");
				X_SwapCall();
            }
            if (y_active && y_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "Y Trigger!");
				Y_SwapCall();
				B_SwapCall();
            }
        }
		else {
            A_Animator.SetBool("leftTrigger", false);
            B_Animator.SetBool("leftTrigger", false);
            X_Animator.SetBool("leftTrigger", false);
            Y_Animator.SetBool("leftTrigger", false);

            if (b_active && b_isEnabled) {
				Shrink();
				Debug.Log(connectedController.GetControllerName() + "B");
			}
			if(x_active && x_isEnabled && hasItem) {
                //Gets handled in OnTriggerStay()
                /*Debug.Log(x_active);
                Debug.Log(x_isEnabled);
                Debug.Log(hasItem);
                Debug.Break();*/
                DropItem();

				Debug.Log(connectedController.GetControllerName() + "X");
			}
			if(y_active && y_isEnabled) {
				Grow();
				Debug.Log(connectedController.GetControllerName() + "Y");
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Stairs") {
			climbable = true;
			rigidBody2D.gravityScale = 0;
		}
		if(collision.tag == "Door") {
			collision.GetComponent<DoorScript>().playerPresent = true;
		}
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if(collision.gameObject.GetComponent<IInteractable>() != null) {
            /*Debug.Log(x_active);
            Debug.Log(x_isEnabled);
            Debug.Log(hasItem);*/
			if(x_active && x_isEnabled && !hasItem) {
				//Gets handled in OnTriggerStay()
				Debug.Log(connectedController.GetControllerName() + "X");
				Interact(collision.gameObject.GetComponent<IInteractable>());
			}
			if(collision.tag == "Door" && x_active && x_isEnabled) {
				if(collision.GetComponent<DoorScript>().playerCanProceed) {
					collision.gameObject.GetComponent<IInteractable>().Act(transform);
				}
			}
		}
		
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if(collision.tag == "Stairs") {
			climbable = false;
			rigidBody2D.gravityScale = gravityScale;
		}
		if(collision.tag == "Door") {
			collision.GetComponent<DoorScript>().playerPresent = false;
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
				graphicsSlot.localScale = new Vector3(SMALL_SIZE, SMALL_SIZE, SMALL_SIZE);
				GetComponent<BoxCollider2D>().size = new Vector2(SMALL_SIZE/2, SMALL_SIZE * 1.2f);
				groundCheck.transform.localPosition = new Vector2(0, SMALL_SIZE / -2);
				break;
			case BlockSize.medium:
				blockSize = BlockSize.small;
				graphicsSlot.localScale = new Vector3(SMALL_SIZE, SMALL_SIZE, SMALL_SIZE);
				GetComponent<BoxCollider2D>().size = new Vector2(SMALL_SIZE / 2, SMALL_SIZE * 1.2f);
				groundCheck.transform.localPosition = new Vector2(0, SMALL_SIZE / -2);
				break;
			case BlockSize.large:
				blockSize = BlockSize.medium;
				graphicsSlot.localScale = new Vector3(MEDIUM_SIZE, MEDIUM_SIZE, MEDIUM_SIZE);
				GetComponent<BoxCollider2D>().size = new Vector2(MEDIUM_SIZE/2, MEDIUM_SIZE * 1.2f);
				groundCheck.transform.localPosition = new Vector2(0, MEDIUM_SIZE / -2);
				break;
		}
	}
	private void Grow() {
		Debug.Log("Grow!");
		switch(blockSize) {
			case BlockSize.small:
				blockSize = BlockSize.medium;
				graphicsSlot.localScale = new Vector3(MEDIUM_SIZE, MEDIUM_SIZE, MEDIUM_SIZE);
				GetComponent<BoxCollider2D>().size = new Vector2(MEDIUM_SIZE / 2, MEDIUM_SIZE * 1.2f);
				groundCheck.transform.localPosition = new Vector2(0, MEDIUM_SIZE / -2);
				break;
			case BlockSize.medium:
				blockSize = BlockSize.large;
				graphicsSlot.localScale = new Vector3(LARGE_SIZE, LARGE_SIZE, LARGE_SIZE);
				GetComponent<BoxCollider2D>().size = new Vector2(LARGE_SIZE/2, LARGE_SIZE * 1.2f);
				groundCheck.transform.localPosition = new Vector2(0, LARGE_SIZE / -2);
				break;
			case BlockSize.large:
				blockSize = BlockSize.large;
				graphicsSlot.localScale = new Vector3(LARGE_SIZE, LARGE_SIZE, LARGE_SIZE);
				GetComponent<BoxCollider2D>().size = new Vector2(LARGE_SIZE/2, LARGE_SIZE * 1.2f);
				groundCheck.transform.localPosition = new Vector2(0, LARGE_SIZE / -2);
				break;
		}
	}
	private void Interact(IInteractable i) {
        Debug.Log(i);
		i.Act(transform);
		//hasItem = true;
	}

	public void PickupItem(Transform item) {
		hasItem = true;
		swapManager.PickupWeapon(item);
		//Insert functionality here @Sten
	}

	public void DropItem() {
		hasItem = false;
		swapManager.DropWeapon();
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
        AGrey_UI.SetActive(!a_isEnabled);
    }
    public void B_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping B bool!");
		b_isEnabled = !b_isEnabled;
		B_UI.SetActive(b_isEnabled);
        BGrey_UI.SetActive(!b_isEnabled);
    }
	public void X_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping X bool!");
		x_isEnabled = !x_isEnabled;
		X_UI.SetActive(x_isEnabled);
		XGrey_UI.SetActive(!x_isEnabled);
    }
    public void Y_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping Y bool!");
		y_isEnabled = !y_isEnabled;
		Y_UI.SetActive(y_isEnabled);
		YGrey_UI.SetActive(!y_isEnabled);
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
