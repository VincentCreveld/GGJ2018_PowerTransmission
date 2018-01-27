using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private int level = 1;

    private GameObject player1;
    private GameObject player2;
    private Vector2 startPosPlayer1;
    private Vector2 startPosPlayer2;

    public void Start()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("More than one levelmanager in scene.");

        Debug.Log("This is level " + level);

        player1 = SwapManager.instance.objPlayer1;
        player2 = SwapManager.instance.objPlayer2;

        GetStartPositions();
    }

    public void Update()
    {
        //Debug.Log(player1.transform.position + " " + player2.transform.position);
        Debug.Log(startPosPlayer1 + " " + startPosPlayer2);

    }

    public void LevelUp()
    {
        GetStartPositions();
        level++;
        Debug.Log("This is level " + level);
    }

    private void GetStartPositions()
    {
        startPosPlayer1 = player1.transform.position;
        startPosPlayer2 = player2.transform.position;
    }

    public void ResetLevel()
    {
        player1.transform.position = startPosPlayer1;
        player2.transform.position = startPosPlayer2;
        Debug.Log("Reset!");
    }
}
