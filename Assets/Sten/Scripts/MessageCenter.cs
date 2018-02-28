using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageCenter : MonoBehaviour {

	public static MessageCenter instance;

	private Canvas messageCanvas;
    //public Text uiText;
    public GameObject uiImage;

	private void Awake() {
		//DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else {
            Destroy(this.gameObject);
            Debug.LogError("Can't resolve UI issues");
        }

		messageCanvas = GetComponent<Canvas>();

        uiImage.SetActive(false);

    }

    public void SendMessage(float duration, string text) {
		StartCoroutine(DisplayMessage(duration/*, text*/));
	}

	public IEnumerator DisplayMessage(float duration /*, string text */) {
        //uiText.text = text;
        uiImage.SetActive(true);
		yield return new WaitForSeconds(duration);
        //uiText.text = "";
        uiImage.SetActive(false);

    }
}
