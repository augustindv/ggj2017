using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SplashScreen : MonoBehaviour {

	int maxPlayers;

	Toggle activeMenuEntry;


	public Button oneKeyboard;
	public Button oneGamepad;
	public Button twoKeyboardGamepad;
	public Button twoGamepads;

	List<Button> activeButtons = new List<Button>();

	private void ActivateButton(Button button) {
		button.gameObject.SetActive (true);
		activeButtons.Add (button);
	}

	void Start () {
		oneGamepad.gameObject.SetActive (false);
		twoKeyboardGamepad.gameObject.SetActive (false);
		twoGamepads.gameObject.SetActive (false);

		ActivateButton (oneKeyboard);
		int numberOfGamepads = Input.GetJoystickNames ().Length;
		if (numberOfGamepads > 0) {
			ActivateButton (oneGamepad);
			ActivateButton (twoKeyboardGamepad);
		}
		if (numberOfGamepads > 1)
			ActivateButton (twoGamepads);

		activeMenuEntry = new Toggle (activeButtons.Count, 0);
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

	public void StartGameOnePlayer(bool gamepadPlayerOne) {
		InputMode one = gamepadPlayerOne ? InputMode.GAMEPAD : InputMode.KEYBOARD;
		StartGame (1, one, InputMode.KEYBOARD);
	}

	public void StartGameTwoPlayer(bool gamepadPlayerOne) {
		InputMode one = gamepadPlayerOne ? InputMode.GAMEPAD : InputMode.KEYBOARD;
		StartGame (2, one, InputMode.GAMEPAD);
	}

	public void StartGame(int numberOfPlayers, InputMode inputPlayerOne, InputMode inputPlayerTwo) {
		GlobalSettings.Instance ().numberOfPlayers = numberOfPlayers;
		GlobalSettings.Instance ().inputPlayerOne = inputPlayerOne;
		GlobalSettings.Instance ().inputPlayerTwo = inputPlayerTwo;
		SceneManager.LoadScene ("Level");
	}
}
