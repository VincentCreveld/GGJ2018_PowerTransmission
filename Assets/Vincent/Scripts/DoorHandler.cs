using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour {

	public DoorScript doorP1;
	public DoorScript doorP2;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void LateUpdate() {
		if(doorP1.playerPresent && doorP2.playerPresent) {
			doorP1.playerCanProceed = true;
			doorP2.playerCanProceed = true;
		}
		else {
			doorP1.playerCanProceed = false;
			doorP2.playerCanProceed = false;
		}
	}
}
