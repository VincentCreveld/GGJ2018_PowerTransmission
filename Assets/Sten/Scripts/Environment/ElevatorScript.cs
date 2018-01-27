using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {

	public void OnColliderEnter2D(Collider2D col) {
        col.transform.parent = this.transform;
        Debug.Log(col);
    }
    public void OnColliderExit2D(Collider2D col) {
        col.transform.parent = null;
        Debug.Log(col);
    }
}
