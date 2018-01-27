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

    public void OnCollisionEnter2D(Collision2D col) {
       if (col.gameObject.GetComponent<AxeScript>() != null) {
            StartCoroutine(DieTree());
         }        
    }

    IEnumerator DieTree() {
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = treeDeath1;
        this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
        yield return new WaitForSeconds(animationTime);
        this.GetComponent<SpriteRenderer>().sprite = treeDeath2;
        this.GetComponent<SpriteRenderer>().sprite.texture.Apply();
    }
}