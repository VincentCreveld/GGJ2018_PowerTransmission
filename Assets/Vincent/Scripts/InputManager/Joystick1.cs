﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick1 : ControllerInput {


	public override bool Trig_CheckInput() {
		if(Input.GetAxis("LeftBumperJ1") >= 1) {
			return true;
		}
		else
			return false;
	}
	public override bool A_CheckInput() {
		if(Input.GetButtonDown("A_ButtonJ1") == true) {
			return true;
		}
		else
			return false;
	}
	public override bool B_CheckInput() {
		if(Input.GetButtonDown("B_ButtonJ1") == true) {
			return true;
		}
		else
			return false;
	}
	public override bool X_CheckInput() {
		if(Input.GetButtonDown("X_ButtonJ1") == true) {
			return true;
		}
		else
			return false;
	}
	public override bool Y_CheckInput() {
		if(Input.GetButtonDown("Y_ButtonJ1") == true) {
			return true;
		}
		else
			return false;
	}

	public override string GetControllerName() {
		return "Joystick 1 ";
	}
}
