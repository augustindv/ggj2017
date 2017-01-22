using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SplashScreen : MonoBehaviour {

	public GameObject credits;

	public void StartGame() {
		SceneManager.LoadScene ("level_design_test");
	}

	public void ShowCredits() {
		credits.SetActive (true);
	}

	public void Exit() {
		Application.Quit ();
	}

	void Update() {
		if (Input.GetButtonDown("Cancel"))
			credits.SetActive(false);
	}
}
