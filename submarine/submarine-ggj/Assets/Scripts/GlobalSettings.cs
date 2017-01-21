using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputMode { KEYBOARD, GAMEPAD }

public class GlobalSettings  {

	public int numberOfPlayers = 1;

	public InputMode inputPlayerOne = InputMode.KEYBOARD;

	public InputMode inputPlayerTwo = InputMode.GAMEPAD;

	private static GlobalSettings instance = new GlobalSettings ();

	public static GlobalSettings Instance() {
		return instance;
	}
}
