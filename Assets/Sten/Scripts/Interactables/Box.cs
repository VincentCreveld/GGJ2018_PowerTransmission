using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable {

    public bool isABox = true;

    //Override Act
    public void Act(Transform parent) {
        Debug.Log("Im a box :)");
        
    }
    public void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.GetComponent<PlayerManager>() != null) {
            //if(Is player large?) 
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;//RigidbodyConstraints2D.FreezePositionX;
            //else{this.getcomponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreePositionX}
        }
    }
}
