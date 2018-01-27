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
    public bool isButton = false;

    [SerializeField]
    private Sprite idleState;
    [SerializeField]
    private Sprite interactedState;

	// Use this for initialization
	public void Act(Transform playerPos) {
        if (!isButton) {
            MoveObject();

        }
	}

    public void OnTriggerEnter2D(Collider2D col) {

    }
    public void OnTriggerExit2D(Collider2D col) {

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
            Debug.Log("At end");
            this.GetComponent<SpriteRenderer>().sprite = idleState;
            this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
        }
        else { isAtEnd = false;
            Debug.Log("To begin");
            this.GetComponent<SpriteRenderer>().sprite = interactedState;
            this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
        }    
        }
	}

