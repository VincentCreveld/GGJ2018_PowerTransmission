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

		playerDeath += PlayerDeath;
	}

	private void DeathEvent() {
        LevelManager.instance.ResetLevel();
        Debug.Log("Died");
    }

	public void PlayerDeath() {
		StartCoroutine(_PlayerDeath());
	}

	private IEnumerator _PlayerDeath() {
		MessageCenter.instance.SendMessage(2, "You Died.");
		SwapManager.instance.DisablePlayers();
		yield return new WaitForSeconds(2);
		SwapManager.instance.EnablePlayers();
		DeathEvent();
	}

}
