using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour, IInteractable {

    private Vector3 initialPos;

    private void Start() {
        initialPos = transform.position;
        EventManager.instance.playerDeath += ResetInteractable;
    }

    public void ResetInteractable() {
        transform.parent = null;
        transform.position = initialPos;
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void Act(Transform playerPos) {
        Debug.Log("Picked up Axe!");
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        playerPos.GetComponent<PlayerManager>().swapManager.PickupWeapon(transform);
    }

}
