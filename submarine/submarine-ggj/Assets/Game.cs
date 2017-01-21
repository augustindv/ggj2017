using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public GameObject[] levelSegments;

	public GameObject nextSegment = null;

	public GameObject world;

	public Submarine submarine;

	public float segmentLength;

	float submarineLength;

	GameObject currentSegment = null;

	GameObject lastSegment = null;

	GameObject PickNextSegment() {
		return levelSegments [0];
	}

	void MoveToNextSegment() {
		if (lastSegment != null)
			Destroy (lastSegment);

		lastSegment = currentSegment;
		currentSegment = nextSegment;

		nextSegment = Instantiate (PickNextSegment ());
		var offset = currentSegment.transform.position.x + segmentLength;
		nextSegment.transform.Translate (new Vector2 (offset, 0));
		nextSegment.transform.parent = world.transform;
	}

	void Start () {
		submarineLength = submarine.transform.lossyScale.x;
		MoveToNextSegment ();
	}

	bool SubmarineIsCloseToNextSegment() {
		return submarine.transform.position.x + submarineLength * 5 >= nextSegment.transform.position.x;
	}

	void Update () {
		if (SubmarineIsCloseToNextSegment ()) {
			MoveToNextSegment ();
		}
	}
}
