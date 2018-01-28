using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Animator anim;
    private int index = 1;

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
                index++;
                break;

            case 2:
                anim.SetTrigger("moveUp2");
                index++;
                break;

            case 3:
                anim.SetTrigger("moveUp3");
                index++;
                break;

            case 4:
                anim.SetTrigger("moveUp4");
                index++;
                break;

            case 5:
                anim.SetTrigger("moveUp5");
                break;

            default:
                break;
        }
    }
}
