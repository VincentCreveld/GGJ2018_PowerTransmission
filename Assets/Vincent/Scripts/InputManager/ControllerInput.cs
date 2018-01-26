using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput {


	public virtual bool Trig_CheckInput() {
		return false;
	}
	public virtual bool A_CheckInput() {
		return false;
	}
	public virtual bool B_CheckInput() {
		return false;
	}
	public virtual bool X_CheckInput() {
		return false;
	}
	public virtual bool Y_CheckInput() {
		return false;
	}

	public virtual string GetControllerName() {
		return "";
	}
}
