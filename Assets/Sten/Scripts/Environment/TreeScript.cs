using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {

    [SerializeField]
    private Sprite treeAlive;
    [SerializeField]
    private Sprite treeDeath1;
    [SerializeField]
    private Sprite treeDeath2;
    [SerializeField]
    private float animationTime;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("COLLTREE");
       if (col.gameObject.GetComponent<AxeScript>() != null) {
            StartCoroutine(DieTree());
         }        
    }

    IEnumerator DieTree() {
        PlayAudio();

        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = treeDeath1;
        this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
        yield return new WaitForSeconds(animationTime);
        this.GetComponent<SpriteRenderer>().sprite = treeDeath2;
        this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
    }

    private void PlayAudio()
    {
        int random = Random.Range(0, 2);

        switch (random)
        {
            case 1:
                audioManager.interactionSound(interactionSounds.chopTree1);
                break;

            case 2:
                audioManager.interactionSound(interactionSounds.chopTree2);
                break;

            default:
                break;
        }

    }
}