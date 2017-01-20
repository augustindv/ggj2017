using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public CrewMember[] crewMembers;

	int activeCrewMember = 0;

	public KeyCode moveLeft = KeyCode.LeftArrow;
	public KeyCode moveRight = KeyCode.RightArrow;
	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;

	public KeyCode act = KeyCode.Space;

	public KeyCode toggleNextCrew = KeyCode.Alpha1;
	public KeyCode togglePreviousCrew = KeyCode.Alpha2;

	CrewMember ActiveCrewMember() {
		return crewMembers [activeCrewMember];
	}

	void Start () {
		
	}

	void FixedUpdate () {
		if (Input.GetKeyDown (toggleNextCrew))
			NextCrewMember ();
		else if (Input.GetKeyDown (togglePreviousCrew))
			PreviousCrewMember ();
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

	void NextCrewMember() {
		if (activeCrewMember == crewMembers.Length - 1)
			activeCrewMember = 0;
		else
			activeCrewMember += 1;
	}

	void PreviousCrewMember() {
		if (activeCrewMember == 0)
			activeCrewMember = crewMembers.Length - 1;
		else
			activeCrewMember -= 1;
	}

	void PerformAction() {
		ActiveCrewMember ().Act ();
	}

	void Move(int horizontal, int vertical) {
		ActiveCrewMember ().Move (horizontal, vertical);
	}
}
