using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeplayer : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Break();
        Debug.Log("yaya");
        if(col.gameObject.GetComponent<IInteractable>() != null) {
            Debug.Log("ya");
            col.gameObject.GetComponent<IInteractable>().Act(this.transform); 
        }
    }
}
