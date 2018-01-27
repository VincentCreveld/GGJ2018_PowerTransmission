using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public List<string> goodbyeWords = new List<string>();
    [SerializeField]
    private Text gameOverText;


    public void Start() {
        gameOverText.text = goodbyeWords[Random.Range(0, 4)];
    }

    public void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.S)) {
            BackToMainMenu();
        }        
    }

    // Update is called once per frame
    public void BackToMainMenu() {
        SceneManager.LoadScene("StartScene");
    }
}
