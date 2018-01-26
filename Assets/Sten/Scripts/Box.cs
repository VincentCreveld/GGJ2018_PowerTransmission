using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable {
   
    public void Act(Transform parent) {
        Debug.Log("Im a box :)");
        this.transform.parent = parent;
        //UPDATE POSITION
    }
}
