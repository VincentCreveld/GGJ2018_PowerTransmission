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
    
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void LateUpdate() {
		if(playerPresent)
			image.color = green;
		else
			image.color = red;
	}

	public void Act(Transform t) {
        if (playerCanProceed)
        {
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

            LevelManager.instance.LevelUp();

        }


    }
}
