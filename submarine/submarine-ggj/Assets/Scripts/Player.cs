using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle {

	private int current;
	private int size;

	public Toggle(int size, int start) {
		this.size = size;
		current = start;
	}

	public int Current() {
		return current;
	}

	public void Next() {
		if (current == size - 1)
			current = 0;
		else
			current += 1;
	}

	public void Previous() {
		if (current == 0)
			current = size - 1;
		else
			current -= 1;
	}
}

public enum PlayerId { ONE, TWO }

public class Player : MonoBehaviour
{
	public Game game;

	public CrewMember[] crewMembers;

	private Dictionary<PlayerId, Toggle> activeCrewMember = new Dictionary<PlayerId, Toggle>();

	private string PREFIX_P1 = "P1_";

	private string PREFIX_P2 = "P2_";

	private bool ButtonDown(string prefix, string button) {
		return Input.GetButtonDown(prefix + button);
	}

	private float Axis(string prefix, string axis) {
		return Input.GetAxis (prefix + axis);
	}

	void Start () {
		activeCrewMember[PlayerId.ONE] = new Toggle (crewMembers.Length, 0);
		activeCrewMember[PlayerId.TWO] = new Toggle (crewMembers.Length, 1);
	}

	CrewMember ActiveCrewMember (PlayerId playerId)
	{
		return crewMembers [activeCrewMember[playerId].Current()];
	}

	void NextCrewMember(PlayerId playerId) {
		activeCrewMember [playerId].Next ();
		if (GlobalSettings.Instance ().numberOfPlayers > 1) {
			if (ActiveCrewMember(PlayerId.TWO) == ActiveCrewMember(PlayerId.TWO))
				activeCrewMember [playerId].Next ();
		}
	}

	void PreviousCrewMember(PlayerId playerId) {
		activeCrewMember [playerId].Previous ();
		if (GlobalSettings.Instance ().numberOfPlayers > 1) {
			if (ActiveCrewMember(PlayerId.TWO) == ActiveCrewMember(PlayerId.TWO))
				activeCrewMember [playerId].Previous ();
		}
	}

	void Update () {
		if (game.CurrentGameMode () == GameMode.RUNNING) {
			if (Input.GetButtonDown("Cancel")) {
				game.PauseGame ();
			}
		} else if (game.CurrentGameMode () == GameMode.PAUSED) {
			if (Input.GetButtonDown("Cancel")) {
				game.UnpauseGame ();
			}
		} else if (game.CurrentGameMode () == GameMode.ENDED) {
			if (Input.GetButtonDown("Submit")) {
				game.RestartGame ();
			}
		}
	}

	void ProcessInputForPlayer(PlayerId playerId, string prefix) {
		if (game.CurrentGameMode () == GameMode.RUNNING) {
			if (ButtonDown(prefix, "Next"))
				NextCrewMember(playerId);
			else if (ButtonDown(prefix, "Prev"))
				PreviousCrewMember (playerId);
			else if (ButtonDown(prefix, "Fire1"))
				PerformAction (playerId);
			else {
				int horizontal = 0;
				if (Axis(prefix, "Horizontal") > 0)
					horizontal = 1;
				else if (Axis(prefix, "Horizontal") < 0)
					horizontal = -1;

				int vertical = 0;
				if (Axis(prefix, "Vertical") > 0)
					vertical = 1;
				else if (Axis(prefix, "Vertical") < 0)
					vertical = -1;

				Move (horizontal, vertical, playerId);
			}
		}
	}

	void FixedUpdate ()
	{
		ProcessInputForPlayer (PlayerId.ONE, PREFIX_P1);
		if (GlobalSettings.Instance().numberOfPlayers > 1)
			ProcessInputForPlayer (PlayerId.TWO, PREFIX_P2);
	}

	void PerformAction (PlayerId playerId)
	{
		ActiveCrewMember (playerId).Act ();
	}

	void Move (int horizontal, int vertical, PlayerId playerId)
	{
		ActiveCrewMember (playerId).Move (horizontal, vertical);
	}
}
