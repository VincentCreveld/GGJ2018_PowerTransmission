using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour {

    private bool p1IsReady = false;
    private bool p2IsReady = false;

    public void fixedUpdate() {//EDIT INPUT KEY
        //P1
        if (Input.GetKeyDown(KeyCode.S)) {
            p1IsReady = true;
            if (p1IsReady && p2IsReady) {
                StartMainGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            p2IsReady = true;
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
