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

public class Player : MonoBehaviour
{

	public Game game;

	public CrewMember[] crewMembers;

	private Toggle activeCrewMember;

	public KeyCode moveLeft = KeyCode.LeftArrow;
	public KeyCode moveRight = KeyCode.RightArrow;
	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;

	public KeyCode act = KeyCode.Space;

	public KeyCode toggleNextCrew = KeyCode.Alpha1;
	public KeyCode togglePreviousCrew = KeyCode.Alpha2;

	void Start () {
		activeCrewMember = new Toggle (crewMembers.Length, 0);
	}

	CrewMember ActiveCrewMember ()
	{
		return crewMembers [activeCrewMember.Current()];
	}

	void Update () {
		if (game.CurrentGameMode () == GameMode.RUNNING) {
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				game.PauseGame ();
			}
		} else if (game.CurrentGameMode () == GameMode.PAUSED) {
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				game.UnpauseGame ();
			}
		} else if (game.CurrentGameMode () == GameMode.ENDED) {
			if (Input.anyKeyDown) {
				game.RestartGame ();
			}
		}
	}

	void FixedUpdate ()
	{
		if (game.CurrentGameMode () == GameMode.RUNNING) {
			if (Input.GetKeyDown (toggleNextCrew))
				activeCrewMember.Next ();
			else if (Input.GetKeyDown (togglePreviousCrew))
				activeCrewMember.Previous ();
			else if (Input.GetKeyDown (act))
				PerformAction ();
			else {
				int horizontal = 0;
				if (Input.GetKey (moveRight))
					horizontal = 1;
				else if (Input.GetKey (moveLeft))
					horizontal = -1;

				int vertical = 0;
				if (Input.GetKey (moveUp))
					vertical = 1;
				else if (Input.GetKey (moveDown))
					vertical = -1;

				Move (horizontal, vertical);
			}
		}
	}

	void PerformAction ()
	{
		ActiveCrewMember ().Act ();
	}

	void Move (int horizontal, int vertical)
	{
		ActiveCrewMember ().Move (horizontal, vertical);
	}
}
