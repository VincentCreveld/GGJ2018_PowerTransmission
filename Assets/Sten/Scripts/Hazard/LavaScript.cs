﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {

    [SerializeField]
    private float raycastDistance = 2f;

    [SerializeField]
    private GameObject lavaBig;
    [SerializeField]
    private GameObject lavaSmall;
    
    void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance);
        if (hit.collider != null) {
            if (hit.collider.gameObject.GetComponent<MyShieldScript>() != null) {
                Debug.Log("Shielded");
                lavaSmall.SetActive(false);
                lavaBig.SetActive(true);
                //block lava stream yall
            }
            else if (hit.collider.gameObject.GetComponent<PlayerManager>() != null) {
                EventManager.instance.playerDeath();        
            }
            //spew lava stream
        }else {
            lavaSmall.SetActive(true);
            lavaBig.SetActive(false);
        }
    }
    }
