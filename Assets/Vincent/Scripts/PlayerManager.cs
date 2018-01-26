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

	private SwapManager swapManager;
	public ControllerInput connectedController;

	private void Start() {
		swapManager = gameObject.GetComponent<SwapManager>();

		SubscribeFunctionality();
		foreach(string item in Input.GetJoystickNames()) {
			Debug.Log(item);
		}
	}

	//input is handled here.
	private void Update() {
		if(connectedController.Trig_CheckInput()) {
			if(connectedController.A_CheckInput() && a_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "A Trigger!");
				//Should be empty because the jump ability can't be transmitted.
			}
			if(connectedController.B_CheckInput() && b_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "B Trigger!");
				B_SwapCall();
			}
			if(connectedController.X_CheckInput() && x_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "X Trigger!");
				X_SwapCall();
			}
			if(connectedController.Y_CheckInput() && y_isEnabled) {
				Debug.Log(connectedController.GetControllerName() + "Y Trigger!");
				Y_SwapCall();
			}
		}
		else {
			if(connectedController.A_CheckInput()) {
				Debug.Log(connectedController.GetControllerName() + "A");
			}
			if(connectedController.B_CheckInput()) {
				Debug.Log(connectedController.GetControllerName() + "B");
			}
			if(connectedController.X_CheckInput()) {
				Debug.Log(connectedController.GetControllerName() + "X");
			}
			if(connectedController.Y_CheckInput()) {
				Debug.Log(connectedController.GetControllerName() + "Y");
			}
		}
	}

	private void SubscribeFunctionality() {
		swapManager.A_ButtonTransmission += A_SwapBool;
		swapManager.B_ButtonTransmission += B_SwapBool;
		swapManager.X_ButtonTransmission += X_SwapBool;
		swapManager.Y_ButtonTransmission += Y_SwapBool;
	}

	#region Bool swap functionality
	public void A_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping A bool!");
		a_isEnabled = !a_isEnabled;
	}
	public void B_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping B bool!");
		b_isEnabled = !b_isEnabled;
	}
	public void X_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping X bool!");
		x_isEnabled = !x_isEnabled;
	}
	public void Y_SwapBool() {
		Debug.Log(connectedController.GetControllerName() + "Swapping Y bool!");
		y_isEnabled = !y_isEnabled;
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
