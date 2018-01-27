using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class controls the transmission of powers between the two players in scene.
public class SwapManager : MonoBehaviour {

	public static SwapManager instance;

	public GameObject objPlayer1;
	public GameObject objPlayer2;

	public PlayerManager player1;
	public PlayerManager player2;

	//Enter button functionality
	public TransmissionEvent A_ButtonTransmission;
	//Enter button functionality
	public TransmissionEvent B_ButtonTransmission;
	//Enter button functionality
	public TransmissionEvent X_ButtonTransmission;
	//Enter button functionality
	public TransmissionEvent Y_ButtonTransmission;

	public Transform pickedUpObj;
	public bool p1IsHolding;

	private void Awake() {
		if(instance == null)
			instance = this;
		else
			Application.Quit();
	}

	private void Start() {
		SetupPlayerManagers();
		Debug.Log(LayerMask.NameToLayer("Default"));
	}


	private void SetupPlayerManagers() {
		player1 = objPlayer1.AddComponent<PlayerManager>();
		player1.connectedController = new Joystick1();
		

		player2 = objPlayer2.AddComponent<PlayerManager>();
		player2.connectedController = new Joystick2();
		

		
		player1.A_ButtonSwap += A_Swap;
		player1.B_ButtonSwap += B_Swap;
		player1.X_ButtonSwap += X_Swap;
		player1.Y_ButtonSwap += Y_Swap;
		player1.a_isEnabled = true;
		player1.x_isEnabled = true;
		player1.Initialize();
		p1IsHolding = true;
		//player1.whatIsGround = gameObject.layer;

		player2.A_ButtonSwap += A_Swap;
		player2.B_ButtonSwap += B_Swap;
		player2.X_ButtonSwap += X_Swap;
		player2.Y_ButtonSwap += Y_Swap;
		player2.a_isEnabled = true;
		player2.b_isEnabled = true;
		player2.y_isEnabled = true;
		player2.Initialize();
		//player2.whatIsGround = gameObject.layer;
	}

	#region Swap Calls
	//These functions are called with input to notify the SwapManager to switch over the controls.
	public void A_Swap() {
		A_ButtonTransmission();
	}
	public void B_Swap() {
		B_ButtonTransmission();
	}
	public void X_Swap() {
		X_ButtonTransmission();
		SwapWeapon();
	}
	public void Y_Swap() {
		Y_ButtonTransmission();
	}
	#endregion

	public void PickupWeapon(Transform t) {
		pickedUpObj = t;
		if(p1IsHolding) {
			pickedUpObj.parent = player1.pickupSlot;
			pickedUpObj.transform.localPosition = Vector3.zero;
		}
		else {
			pickedUpObj.parent = player2.pickupSlot;
			pickedUpObj.transform.localPosition = Vector3.zero;
		}
	}

	public void DropWeapon() {
		Debug.Log("Reached drop");
		pickedUpObj.transform.parent = null;
		pickedUpObj = null;
	}

	public void SwapWeapon() {
		if(p1IsHolding && player1.hasItem) {
			pickedUpObj.parent = player2.pickupSlot;
			p1IsHolding = !p1IsHolding;
			pickedUpObj.transform.localPosition = Vector3.zero;
			player1.hasItem = false;
			player2.hasItem = true;
		}
		else if (player2.hasItem) {
			pickedUpObj.parent = player1.pickupSlot;
			p1IsHolding = !p1IsHolding;
			pickedUpObj.transform.localPosition = Vector3.zero;
			player1.hasItem = true;
			player2.hasItem = false;
		}
	}
}
