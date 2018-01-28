using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Animator anim;
    //private int index = 1;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void MoveUp()
    {
        switch (LevelManager.instance.currentLevel)
        {
            case 1:
                anim.SetTrigger("moveUp1");
                LevelManager.instance.currentLevel++;
                //index++;
                break;
            case 2:
                anim.SetTrigger("moveUp2");
                LevelManager.instance.currentLevel++;
                //index++;
                break;

            case 3:
                anim.SetTrigger("moveUp3");
                LevelManager.instance.currentLevel++;
                //index++;
                break;

            case 4:
                anim.SetTrigger("moveUp4");
                LevelManager.instance.currentLevel++;
                ///index++;
                break;

            case 5:
                anim.SetTrigger("moveUp5");
                LevelManager.instance.currentLevel++;
                //index++;
                break;

            default:
                break;
        }
    }
}
