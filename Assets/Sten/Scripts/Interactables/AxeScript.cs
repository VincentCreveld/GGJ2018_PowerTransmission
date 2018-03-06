using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour, IInteractable {

    private AudioManager audioManager;

    private Vector3 initialPos;

    private void Init() {
        audioManager = FindObjectOfType<AudioManager>();

        initialPos = transform.position;
        EventManager.instance.playerDeath += ResetInteractable;
    }

    public void ResetInteractable() {
        transform.parent = null;
        transform.position = initialPos;
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        this.gameObject.GetComponent<Rigidbody2D>().useFullKinematicContacts = false;

        int random = Random.Range(0, 2);
        if (random == 0)
            audioManager.interactionSound(interactionSounds.dropSword1);
        else if (random == 1)
            audioManager.interactionSound(interactionSounds.dropSword2);
    }

    public void Act(Transform playerPos) {
        Init();
        Debug.Log("Picked up Axe!");
        playerPos.gameObject.GetComponent<PlayerManager>().hasItem = true;
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        this.gameObject.GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
        playerPos.GetComponent<PlayerManager>().swapManager.PickupWeapon(transform);
        audioManager.interactionSound(interactionSounds.pickUp);
    }

}
