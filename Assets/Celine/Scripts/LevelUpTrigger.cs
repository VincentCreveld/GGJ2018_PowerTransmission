using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTrigger : MonoBehaviour
{
    // Boolean to check if a player has already entered the trigger
    public bool entered = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() && entered == false)
        {
            LevelManager.instance.LevelUp();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
