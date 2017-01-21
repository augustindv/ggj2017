using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

	public float minDepth;

	public float maxDepth;

	public float climbSpeed;

	float depth;

	float thrust;

	public Transform world;

	float MaxDepth() {
		return depth + maxDepth;
	}

	float MinDepth() {
		return depth + minDepth;
	}

	public void AdjustThrust(float newThrust) {
		
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

	}

	// Use this for initialization
	void Start () {
		depth = world.position.y;
	}
	
	// Update is called once per frame
	void Update () {





		
	}
}
