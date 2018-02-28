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

            switch (LevelManager.instance.currentLevel)
            {
                case 0:
                    audioManager.interactionSound(interactionSounds.deur1);
                    break;

                case 1:
                    audioManager.interactionSound(interactionSounds.deur2);
                    break;

                case 2:
                    audioManager.interactionSound(interactionSounds.deur3);
                    break;

                case 3:
                    audioManager.interactionSound(interactionSounds.deur4);
                    break;

                case 4:
                    audioManager.interactionSound(interactionSounds.deur5);
                    break;

                default:
                    break;
            }
        }
		else {
			doorP1.playerCanProceed = false;
			doorP2.playerCanProceed = false;
		}
	}
}
