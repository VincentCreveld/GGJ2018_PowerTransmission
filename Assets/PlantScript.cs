using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour {

	public void OnColliderEnter2D(Collider2D col) {
        if(col.gameObject.GetComponent<PlayerManager>() != null) {
                EventManager.instance.playerDeath();
        }else {
            //if(col.gameObject.GetComponent<>())

        }
        }

    private void diePlant() {

    }


    }

