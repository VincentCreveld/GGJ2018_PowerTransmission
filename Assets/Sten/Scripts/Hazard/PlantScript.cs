using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour {


    [SerializeField]
    private Sprite plantAlive;
    [SerializeField]
    private Sprite plantDeath1;
    [SerializeField]
    private Sprite plantDeath2;
    [SerializeField]
    private float animationTime;

    private bool isAlive = true;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    public void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.GetComponent<PlayerManager>() != null) {
            //plant attack sound
            int random = Random.Range(0, 3);
            if (random == 0)
                audioManager.interactionSound(interactionSounds.plantAttack1);
            if (random == 1)
                audioManager.interactionSound(interactionSounds.plantAttack2);
            if (random == 2)
                audioManager.interactionSound(interactionSounds.plantAttack3);
            EventManager.instance.playerDeath();
        }else {
            if (col.gameObject.GetComponent<SwordScript>() != null && isAlive) {
                //plant die sound
                int random = Random.Range(0, 3);
                if(random == 0) 
                    audioManager.interactionSound(interactionSounds.attack1);
                if(random == 1)
                    audioManager.interactionSound(interactionSounds.attack2);
                if (random == 2)
                    audioManager.interactionSound(interactionSounds.attack3);
                StartCoroutine(DiePlant());
            }
        }
        }

    IEnumerator DiePlant() {
        Debug.Log("Plant dying");
        isAlive = false;

        int random = Random.Range(0, 3);


        Destroy(this.GetComponent<Animator>());
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = plantDeath1;
        this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
        yield return new WaitForSeconds(animationTime);
        this.GetComponent<SpriteRenderer>().sprite = plantDeath2;
        this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
    }
    }


    

