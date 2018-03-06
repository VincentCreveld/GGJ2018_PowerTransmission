using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    AsyncOperation asyncLoadLevel;

    private MoveCamera moveCamera;
    public AudioManager audioManager;

    public int level = 1;
    public int currentLevel;

    private GameObject player1;
    private GameObject player2;
    private Vector2 startPosPlayer1;
    private Vector2 startPosPlayer2;
    [SerializeField]
    private List<Transform> player1SpawnPositions = new List<Transform>();
    [SerializeField]
    private List<Transform> player2SpawnPositions = new List<Transform>();

    public void Start()
    {
        DontDestroyOnLoad(this);
        if (instance == null) { 
            instance = this;
            Debug.Log("This is level " + level);

            moveCamera = FindObjectOfType<MoveCamera>();
            audioManager = FindObjectOfType<AudioManager>();

            audioManager.soundTrack(musicTrack.gameSound);
            audioManager.ambianceSoundTrack(environmentalSound.ambience);

            player1 = SwapManager.instance.objPlayer1;
            player2 = SwapManager.instance.objPlayer2;

            GetStartPositions();
            }
        else {
            Destroy(this.gameObject);
            Debug.LogError("More than one levelmanager in scene.");
        }

        
    }

    public void Initialize() {
        //player1SpawnPositions.Clear();
        //player2SpawnPositions.Clear();
        player1 = SwapManager.instance.objPlayer1;
        player2 = SwapManager.instance.objPlayer2;

        moveCamera = FindObjectOfType<MoveCamera>();
        audioManager = FindObjectOfType<AudioManager>();

        audioManager.soundTrack(musicTrack.gameSound);
        audioManager.ambianceSoundTrack(environmentalSound.ambience);

        player1SpawnPositions = MessageCenter.instance.gameObject.GetComponent<DoorHolder>().StoreDoors(1);
        player2SpawnPositions = MessageCenter.instance.gameObject.GetComponent<DoorHolder>().StoreDoors(2);

        moveCamera.MoveUp(false);

        GetStartPositions();

        player1.transform.position = startPosPlayer1;
        player2.transform.position = startPosPlayer2;
        }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp();
            Debug.Log("Move up!");
        }
    }

    public void LevelUp() {
        // Get the new reset positions for the player
        GetStartPositions();
        Debug.Log("Got sets");

        // Move the camera up to the new level
        level  = currentLevel + 1;
        moveCamera.MoveUp(true);

        int random = Random.Range(0, 2);
        if (random == 0)
            audioManager.uiSoundTrack(uiSounds.cameraSwitch1);
        else
            audioManager.uiSoundTrack(uiSounds.cameraSwitch2);


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
        //SceneManager.LoadScene("Prototype2Art");
        StartCoroutine(_ResetLevel());

        //Initialize();
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
        startPosPlayer2 = player2SpawnPositions[level].position;
        return startPosPlayer2;
    }
    private IEnumerator _ResetLevel() {
        asyncLoadLevel = SceneManager.LoadSceneAsync("Prototype2Art", LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone) {
            print("Loading the Scene");
            yield return null;
            Debug.Log("Part 1");
            //SwapManager.instance.Initialize();
            }
        Debug.Log("Part 2");
        Initialize();
        }

}
