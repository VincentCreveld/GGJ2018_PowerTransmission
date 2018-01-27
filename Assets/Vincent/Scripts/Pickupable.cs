using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour, IInteractable {
	public void Act(Transform t) {
		Debug.Log("Picked up!");
		t.GetComponent<PlayerManager>().swapManager.PickupWeapon(transform);
	}
}
