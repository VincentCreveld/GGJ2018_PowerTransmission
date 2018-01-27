using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageCenter : MonoBehaviour {

	public static MessageCenter instance;

	private Canvas messageCanvas;
	public Text uiText;

	private void Awake() {
		DontDestroyOnLoad(this);
		if(instance == null)
			instance = this;
		else if(instance != this)
			DestroyImmediate(this);
		else
			Debug.LogError("Can't resolve UI issues");

		messageCanvas = GetComponent<Canvas>();
	}

	public void SendMessage(float duration, string text) {
		StartCoroutine(DisplayMessage(duration, text));
	}

	public IEnumerator DisplayMessage(float duration, string text) {
		uiText.text = text;
		yield return new WaitForSeconds(duration);
		uiText.text = "";
	}
}
