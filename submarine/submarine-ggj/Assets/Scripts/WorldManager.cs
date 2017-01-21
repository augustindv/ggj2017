using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public GameObject[] levelSegments;

	public GameObject nextSegment = null;

	public Submarine submarine;

	public float segmentLength;

	float submarineLength;

	// Compensate for moving by one segment right at the start.
	int travelledSegments = -1;

	GameObject currentSegment = null;

	GameObject lastSegment = null;

	GameObject PickNextSegment() {
		var selectedId = Random.Range (0, levelSegments.Length);
		return levelSegments [selectedId];
	}

	void MoveToNextSegment() {
		travelledSegments += 1;

		if (lastSegment != null)
			Destroy (lastSegment);

		lastSegment = currentSegment;
		currentSegment = nextSegment;

		nextSegment = Instantiate (PickNextSegment ());
		var offset = currentSegment.transform.position.x + segmentLength;
		nextSegment.transform.Translate (new Vector2 (offset, 0));
		nextSegment.transform.parent = gameObject.transform;
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
