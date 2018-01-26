using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class controls the transmission of powers between the two players in scene.
public class SwapManager : MonoBehaviour {

	private PlayerManager player1;
	private PlayerManager player2;

	//Enter button functionality
	public TransmissionEvent A_ButtonTransmission;
	//Enter button functionality
	public TransmissionEvent B_ButtonTransmission;
	//Enter button functionality
	public TransmissionEvent X_ButtonTransmission;
	//Enter button functionality
	public TransmissionEvent Y_ButtonTransmission;

	private void Start() {
		SetupPlayerManagers();
	}


	private void SetupPlayerManagers() {
		player1 = gameObject.AddComponent<PlayerManager>();
		player2 = gameObject.AddComponent<PlayerManager>();

		player1.A_ButtonSwap += A_Swap;
		player1.B_ButtonSwap += B_Swap;
		player1.X_ButtonSwap += X_Swap;
		player1.Y_ButtonSwap += Y_Swap;

		player2.A_ButtonSwap += A_Swap;
		player2.B_ButtonSwap += B_Swap;
		player2.X_ButtonSwap += X_Swap;
		player2.Y_ButtonSwap += Y_Swap;


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
	}
	public void Y_Swap() {
		Y_ButtonTransmission();
	}
	#endregion

}
