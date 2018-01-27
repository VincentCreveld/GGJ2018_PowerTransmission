using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public static EventManager instance;
	public ManagerEvent playerDeath;
	public int deathCount;

	private void Awake() {
		if(instance == null)
			instance = this;
		else
			Debug.LogError("More than one eventmanager in scene.");

		playerDeath += DeathEvent;
	}

	private void DeathEvent() {
		Debug.Log("Death");
	}

}
