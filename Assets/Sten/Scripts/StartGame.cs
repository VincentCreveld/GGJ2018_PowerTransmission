using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour {

	public Transform p1UI;
	public Transform p2UI;

    private bool p1IsReady = false;
    private bool p2IsReady = false;

	public void Update() {//EDIT INPUT KEY
        //P1
        if (Input.GetButtonDown("A_ButtonJ1")) {
            p1IsReady = true;
			p1UI.GetChild(0).gameObject.SetActive(true);
			p1UI.GetChild(1).gameObject.SetActive(false);
			if (p1IsReady && p2IsReady) {
                StartMainGame();
            }
        }
        if (Input.GetButtonDown("A_ButtonJ2")) {
            p2IsReady = true;
			p2UI.GetChild(0).gameObject.SetActive(true);
			p2UI.GetChild(1).gameObject.SetActive(false);
			if(p1IsReady && p2IsReady) {
                StartMainGame();
            }
        }
    }

	// Update is called once per frame
	public void StartMainGame() {
        SceneManager.LoadScene("MainGame");
	}
}
