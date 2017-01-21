using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

	public static readonly float HP_MAX = 100;
	public static readonly float ENERGY_MAX = 100;
	public static readonly float OXYGEN_MAX = 100;

	public float oxygenUsedPerSecond = 0.25f;
	public float damagePerSecondForMissingOxygen = 1.0f;
	public float sonarEnergyCost = 2.0f;

	public float top;
	public float bottom;

	public float verticalSpeed = 0.5f;
	public float horizontalSpeed;

	public float hp;
	public float energy;
	public float oxygen;

	public Transform world;

	float depth;

	public bool HasEnergy(float minimum) {
		return energy >= minimum;
	}

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
		StartCoroutine (CheckOxygen ());
	}

	IEnumerator CheckOxygen() {
		while (true) {
			oxygen = Mathf.Max (0.0f, oxygen - oxygenUsedPerSecond);
			if (oxygen < 1.0f)
				TakeDamage (damagePerSecondForMissingOxygen);
			yield return new WaitForSeconds(1.0f);
		}
	}

	void Update () {
		MoveWorldHorizontally ();
	}

	public void Die() {
		horizontalSpeed = 0;
	}
}
