using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour, IInteractable {

	public bool playerPresent = false;
	public bool playerCanProceed = false;
    [SerializeField]
    private Animator doorLight;
    
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

    }

    private void LateUpdate() {
        if (playerPresent)
            doorLight.SetBool("LightOn", true);
        else
            doorLight.SetBool("LightOn", false);
    }

	public void Act(Transform t) {
        //LevelManager.instance.Initialize();
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
			SwapManager.instance.p1IsHolding = true;
            playerCanProceed = false;

        }


    }
}
