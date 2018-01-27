using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTrigger : MonoBehaviour
{
    private LevelManager levelManager;

    // Boolean to check if a player has already entered the trigger
    private bool firstEntered = false;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && firstEntered == false)
        {
            firstEntered = true;
        }
        else if (collision.tag == "Player" && firstEntered == true)
        {
            levelManager.LevelUp();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
