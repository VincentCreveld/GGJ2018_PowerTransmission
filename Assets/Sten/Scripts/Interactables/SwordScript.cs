using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour, IInteractable {

	public void Act (Transform playerPos) {
        Debug.Log("Picked up sword!");
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        playerPos.GetComponent<PlayerManager>().swapManager.PickupWeapon(transform);
    }
	
}
