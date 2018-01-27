using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int level = 1;

    public void Start()
    {
        Debug.Log("This is level " + level);
    }

    public void LevelUp()
    {
        level++;
        Debug.Log("This is level " + level);
    }
}
