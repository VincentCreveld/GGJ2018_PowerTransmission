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

	private void Start() {
		swapManager = gameObject.GetComponent<SwapManager>();

		SubscribeFunctionality();
	}

	//input is handled here.
	private void Update() {
		if(Input.GetAxis("LeftBumper") >= 1) {
			Debug.Log("Bump!");
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
		a_isEnabled = !a_isEnabled;
	}
	public void B_SwapBool() {
		b_isEnabled = !b_isEnabled;
	}
	public void X_SwapBool() {
		x_isEnabled = !x_isEnabled;
	}
	public void Y_SwapBool() {
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
