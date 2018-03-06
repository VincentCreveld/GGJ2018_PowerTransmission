using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyScript : MonoBehaviour {

    [SerializeField]
    private Transform platformUp;
    [SerializeField]
    private Transform startPosUp;
    [SerializeField]
    private Transform endPosUp;

    [SerializeField]
    private Transform platformDown;
    [SerializeField]
    private Transform startPosDown;
    [SerializeField]
    private Transform endPosDown;

    [SerializeField]
    private float moveSpeed;
    private bool isMoving;
    

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.GetComponent<Box>() != null) {
            //do it
            isMoving = true;
            if (platformUp.gameObject.GetComponent<AudioSource>()) {
                platformUp.gameObject.GetComponent<AudioSource>().Play();
                }
        }
    }

	void Update () {
        if (isMoving) {
            float step = moveSpeed * Time.deltaTime;
            platformUp.transform.position = Vector3.MoveTowards(platformUp.position, endPosUp.position, step);
            platformDown.transform.position = Vector3.MoveTowards(platformDown.position, endPosDown.position, step);
            if(platformUp == endPosUp && platformDown == endPosDown) {
                isMoving = false;
            }
        }
	}
}
