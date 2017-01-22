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

	public CameraController cameraController;

	Toggle activeCrewMember;

	private bool ButtonDown(string button) {
		return Input.GetButtonDown(button);
	}

	private float Axis(string axis) {
		return Input.GetAxis (axis);
	}

	void Start () {
		activeCrewMember = new Toggle (crewMembers.Length, 0);
		cameraController.SetTarget (ActiveCrewMember ().cameraPosition);
	}

	CrewMember ActiveCrewMember ()
	{
		return crewMembers [activeCrewMember.Current()];
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

	void FixedUpdate ()
	{
		if (game.CurrentGameMode () == GameMode.RUNNING) {
			if (ButtonDown("Next"))
				activeCrewMember.Next ();
			else if (ButtonDown("Prev"))
				activeCrewMember.Previous ();
			else if (ButtonDown("Fire1"))
				PerformAction ();
			else {
				int horizontal = 0;
				if (Axis("Horizontal") > 0)
					horizontal = 1;
				else if (Axis("Horizontal") < 0)
					horizontal = -1;

				int vertical = 0;
				if (Axis("Vertical") > 0)
					vertical = 1;
				else if (Axis("Vertical") < 0)
					vertical = -1;

				Move (horizontal, vertical);
			}
			cameraController.SetTarget (ActiveCrewMember ().cameraPosition);
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
