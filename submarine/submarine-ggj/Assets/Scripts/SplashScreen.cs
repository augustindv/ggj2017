using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SplashScreen : MonoBehaviour {

	public void StartGameOnePlayer() {
		StartGame (1);
	}

	public void StartGameTwoPlayer() {
		StartGame (2);
	}

	public void StartGame(int numberOfPlayers) {
		GlobalSettings.Instance ().numberOfPlayers = numberOfPlayers;
		SceneManager.LoadScene ("level_with_ui");
	}
}
