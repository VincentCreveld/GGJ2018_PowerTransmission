using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTrigger : MonoBehaviour
{
    // Boolean to check if a player has already entered the trigger
    public bool firstEntered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerManager>() && firstEntered == false)
        {
            firstEntered = true;
        }
        else if (collision.gameObject.GetComponent<PlayerManager>() && firstEntered == true)
        {
            LevelManager.instance.LevelUp();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
