using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SplashScreen : MonoBehaviour {

	int maxPlayers;

	Toggle activeMenuEntry;


	public Button onePlayer;
	public Button twoPlayers;

	List<Button> activeButtons = new List<Button>();

	private void ActivateButton(Button button) {
		button.gameObject.SetActive (true);
		activeButtons.Add (button);
	}

	void Start () {
		ActivateButton (onePlayer);
		ActivateButton (twoPlayers);
		activeMenuEntry = new Toggle (2, 0);
	}

	void Update () {
		float vertical = Input.GetAxis ("Vertical");
		if (vertical > 0)
			activeMenuEntry.Previous ();
		else if (vertical < 0)
			activeMenuEntry.Next ();

		Button button = activeButtons [activeMenuEntry.Current ()];
		EventSystem.current.SetSelectedGameObject(button.gameObject, new BaseEventData(EventSystem.current));
	}

	public void StartGameOnePlayer() {
		StartGame (1);
	}

	public void StartGameTwoPlayer() {
		StartGame (2);
	}

	public void StartGame(int numberOfPlayers) {
		GlobalSettings.Instance ().numberOfPlayers = numberOfPlayers;
		SceneManager.LoadScene ("Level");
	}
}
