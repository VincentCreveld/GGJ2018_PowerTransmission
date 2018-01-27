using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour, IInteractable {

	public bool playerPresent = false;
	public bool playerCanProceed = false;

	public Color red = Color.red;
	public Color green = Color.green;

	//public Texture2D light = new Texture2D(1, 1);
	public Image image;


	private void LateUpdate() {
		if(playerPresent)
			image.color = green;
		else
			image.color = red;
	}

	public void Act(Transform t) {
		LevelManager.instance.LevelUp();
	}
}
