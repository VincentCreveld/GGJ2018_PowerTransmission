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
        if (col.gameObject.GetComponent<PlayerManager>() != null) {
            if (col.gameObject.GetComponent<PlayerManager>().blockSize == BlockSize.large) {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None; }
            else { this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX; }
            }
        }
    }
