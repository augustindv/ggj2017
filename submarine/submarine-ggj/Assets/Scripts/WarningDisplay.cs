using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningDisplay : MonoBehaviour {

	public Text display;

	public float duration = 8;

	Coroutine fadeout = null;

	public void ShowWarning(string text) {
		if (fadeout != null)
			StopCoroutine (fadeout);

		fadeout = StartCoroutine (ShowMessageAndFadeout (text));
	}

	void UpdateAlpha(float newAlpha) {
		display.color = new Color (display.color.r, display.color.g, display.color.b, newAlpha);
	}

	IEnumerator ShowMessageAndFadeout(string text) {
		display.gameObject.SetActive (true);
		display.text = text;
		UpdateAlpha (1);

		yield return new WaitForSeconds (duration);

		float alpha = 1;
		while (alpha > 0) {
			alpha = Mathf.Max(0, alpha - Time.fixedDeltaTime);
			UpdateAlpha (alpha);
			yield return new WaitForFixedUpdate ();
		}

		display.gameObject.SetActive (false);
		fadeout = null;
		yield return null;
	}
}
