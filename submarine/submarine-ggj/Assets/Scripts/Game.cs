using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode { 
	RUNNING, 
	PAUSED, 
    ENDED } 

public class Game : MonoBehaviour {

	public Submarine submarine;

	public WorldManager world;

	GameMode gameMode = GameMode.RUNNING;

	public GameMode CurrentGameMode() {
		return gameMode;
	}

	void Update () {
		if (submarine.hp <= 0) {
			gameMode = GameMode.ENDED;
			submarine.Die ();
			ShowHighscore ();
		}
	}

	int DistanceTravelled() {
		return (int) -world.transform.position.x;
	}

	void ShowHighscore() {
		
	}

	public void PauseGame () {
		if (gameMode == GameMode.RUNNING) {
			gameMode = GameMode.PAUSED;
			Time.timeScale = 0;
		}
	}

	public void UnpauseGame() {
		if (gameMode == GameMode.PAUSED) {
			gameMode = GameMode.RUNNING;
			Time.timeScale = 1;
		}
	}

	public void RestartGame() {
		if (gameMode == GameMode.ENDED) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
}
