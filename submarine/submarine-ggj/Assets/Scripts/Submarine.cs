using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

	public float minDepth;

	public float maxDepth;

	public float climbSpeed;

	public float thrust;

	public float health;

	public Transform world;

	float depth;

	public void AdjustThrust(float multiplier) {
		thrust = thrust * multiplier;
	}

	public void AdjustDepth(int direction) {
		var movement = Time.fixedDeltaTime * climbSpeed;
		var currentPosition = world.position;

		float position = 0;
		if (direction > 0 && world.position.y < MinDepth()) {
			position = Mathf.Min (MinDepth (), world.position.y + movement);
		} else if (direction < 0 && world.position.y > MaxDepth()) {
			position = Mathf.Max (MaxDepth (), world.position.y + movement);
		}

		world.position = new Vector3 (currentPosition.x, position, currentPosition.z);
	}

	void TakeDamage(float damage) {
		health -= damage;
		if (health <= 0) {
			// TODO: loose game.
		}
	}

	float MaxDepth() {
		return depth + maxDepth;
	}

	float MinDepth() {
		return depth + minDepth;
	}

	void OnTriggerEnter(Collider other) {
		var obstacle = other.GetComponent<Obstacle> ();
		if (obstacle != null) {
			TakeDamage (obstacle.damage);
			var destructible = other.GetComponent<Destructible> ();
			if (destructible != null)
				destructible.Destroy ();
		}
	}

	void MoveWorldHorizontally() {
		var movement = Time.deltaTime * thrust;
		var currentPosition = world.position;
		world.position = new Vector3 (currentPosition.x - movement, currentPosition.y, currentPosition.z);
	}

	void Start () {
		depth = world.position.y;
	}

	void Update () {
		MoveWorldHorizontally ();
	}
}
