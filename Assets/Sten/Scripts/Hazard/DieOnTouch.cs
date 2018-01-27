using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnTouch : MonoBehaviour {
    //Player dies upon touching any of these objects
	public void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.GetComponent<PlayerManager>() != null) {
            EventManager.instance.playerDeath();
        }
    }
}
