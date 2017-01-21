using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	public GameObject highscoreMenu;

	public Text highscoreText;

	string initialText;

	void Start() {
		initialText = highscoreText.text;
	}

	public void ShowHighscore(int highscore) {
		highscoreText.text = initialText + " " + highscore + "m";
		highscoreMenu.SetActive (true);
	}

	public void RestartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		
	}
	public void BackToMenu() {
		SceneManager.LoadScene ("splash_screen");
	}

	public void Exit() {
		Application.Quit ();
	}
}
