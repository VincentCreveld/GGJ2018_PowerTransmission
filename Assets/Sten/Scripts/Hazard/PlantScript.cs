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


	public void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.GetComponent<PlayerManager>() != null) {
                EventManager.instance.playerDeath();
        }else {
            if (col.gameObject.GetComponent<SwordScript>() != null && isAlive) {
                StartCoroutine(DiePlant());
            }
        }
        }

    IEnumerator DiePlant() {
        Debug.Log("Plant dying");
        isAlive = false;
        Destroy(this.GetComponent<Animator>());
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = plantDeath1;
        this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
        yield return new WaitForSeconds(animationTime);
        this.GetComponent<SpriteRenderer>().sprite = plantDeath2;
        this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
    }
    }


    

