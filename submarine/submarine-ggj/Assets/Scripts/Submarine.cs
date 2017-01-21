using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

	public static readonly float HP_MAX = 100;
	public static readonly float ENERGY_MAX = 100;
	public static readonly float OXYGEN_MAX = 100;

	public float top;
	public float bottom;

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

		float position = world.position.y - movement * direction;
		position = Mathf.Clamp (position, Bottom (), Top ());
		world.position = new Vector3 (currentPosition.x, position, currentPosition.z);
	}

	void TakeDamage(float damage) {
		hp -= damage;
	}

	float Top() {
		return depth + top;
	}

	float Bottom() {
		return depth + bottom;
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
		MoveWorldHorizontally ();
	}

	public void Die() {
		horizontalSpeed = 0;
	}
}
