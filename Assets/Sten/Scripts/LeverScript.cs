using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour, IInteractable {

    [SerializeField]
    public Transform objectToMove;
    [SerializeField]
    private Transform startPos;
    [SerializeField]
    private Transform endPos;
    [SerializeField]
    private float moveSpeed;

    private bool isAtEnd = false;
    
	// Use this for initialization
	public void Act(Transform playerPos) {
        MoveObject();
	}
	public void Update() {
        float step = moveSpeed * Time.deltaTime;
        if (!isAtEnd) {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.position, endPos.position, step);
        }else { objectToMove.transform.position = Vector3.MoveTowards(objectToMove.position, startPos.position, step); }
    }
	// Update is called once per frame
    
	private void MoveObject() {
        if (objectToMove.position == endPos.position) {
            isAtEnd = true;
        }
        else { isAtEnd = false; }    
            //        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            //objectToMove.transform.position = Vector3.MoveTowards(startPos, endPos,);
        }
	}

