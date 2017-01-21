using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

	public float minDepth;
	public float maxDepth;

	public float verticalSpeed = 0.5f;
	public float horizontalSpeed;

	public float hp;
	public float energy;
	public float oxygen;

	public Transform world;

	float depth;

	public void AdjustThrust(float multiplier) {
		horizontalSpeed = horizontalSpeed * multiplier;
	}

	public void AdjustDepth(int direction) {
		var movement = Time.fixedDeltaTime * verticalSpeed;
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
		hp -= damage;
		if (hp <= 0) {
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
		var movement = Time.deltaTime * horizontalSpeed;
		world.Translate(new Vector3 (-movement, 0, 0));
	}

	void Start () {
		depth = world.position.y;
	}

	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			AdjustDepth (1);
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			AdjustDepth (-1);
		}

		MoveWorldHorizontally ();
	}
}
