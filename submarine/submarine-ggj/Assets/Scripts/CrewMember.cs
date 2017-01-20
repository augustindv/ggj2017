using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMember : MonoBehaviour {

	public static readonly string TAG_LADDER = "Ladder";

	public float speed = 2.5f;

	public float climbSpeed = 1.5f;

	private Rigidbody rigidBody;

	private int collidingLadders = 0;

	void Start () {
		rigidBody = GetComponentInChildren<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == TAG_LADDER) {
			UpdateLadders (1);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == TAG_LADDER) {
			UpdateLadders (-1);
		}
	}

	bool IsOnLadder() {
		return collidingLadders > 0;
	}

	private void UpdateLadders(int difference) {
		collidingLadders += difference;
		rigidBody.useGravity = collidingLadders == 0;
		Debug.Log ("Update ladders (" + difference + ") -> " + collidingLadders);
	}

	public void Act() {
		
	}

	private float CurrentSpeed() {
		float currentSpeed = IsOnLadder () ? climbSpeed : speed;
		return currentSpeed * Time.fixedDeltaTime;
	}

	public void Move(int horizontal, int vertical) {
		if (!IsOnLadder ())
			vertical = 0;

		var currentPosition = rigidBody.transform.position;

		var movement = new Vector3 (horizontal * CurrentSpeed(), vertical * CurrentSpeed(), 0);

		rigidBody.MovePosition (currentPosition + movement);
	}
}
