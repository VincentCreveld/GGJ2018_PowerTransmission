using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private MoveCamera moveCamera;
    private AudioManager audioManager;

    private int level = 1;
    private int currentLevel;

    private GameObject player1;
    private GameObject player2;
    private Vector2 startPosPlayer1;
    private Vector2 startPosPlayer2;
    [SerializeField]
    private List<Transform> player1SpawnPositions = new List<Transform>();
    [SerializeField]
    private List<Transform> player2SpawnPositions = new List<Transform>();

    public void awake() {
    }

    public void Start()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else {
            Destroy(this.gameObject);
            Debug.LogError("More than one levelmanager in scene.");
        }

        Debug.Log("This is level " + level);

        moveCamera = FindObjectOfType<MoveCamera>();
        audioManager = FindObjectOfType<AudioManager>();

        audioManager.soundTrack(musicTrack.gameSound);

        player1 = SwapManager.instance.objPlayer1;
        player2 = SwapManager.instance.objPlayer2;

        GetStartPositions();
    }

    public void LevelUp() {
        // Get the new reset positions for the player
        GetStartPositions();
        Debug.Log("Got sets");
        // Move the camera up to the new level
        
            moveCamera.MoveUp();
            audioManager.uiSoundTrack(uiSounds.cameraSwitch);
            level = currentLevel + 1;
            SetPositions();
            Debug.Log("This is level " + level);
        
    }

    // Get positions for the players to go back to when someone dies
    private void GetStartPositions()
    {
        startPosPlayer1 = player1SpawnPositions[level].position;
        startPosPlayer2 = player2SpawnPositions[level].position;
    }

    // Reset player positions
    public void ResetLevel()
    {
        SceneManager.LoadScene("Prototype2");
        player1.transform.position = startPosPlayer1;
        player2.transform.position = startPosPlayer2;
    }

    public void SetPositions() {
        player1.transform.position = player1SpawnPositions[level].position;
        player2.transform.position = player2SpawnPositions[level].position;
        currentLevel = level;
    }

    public Vector2 SetPlayer1Pos() {
        startPosPlayer1 = player1SpawnPositions[level].position;
        return startPosPlayer1;
    }
    public Vector2 SetPlayer2Pos() {
        startPosPlayer2 = player1SpawnPositions[level].position;
        return startPosPlayer2;
    }
}
