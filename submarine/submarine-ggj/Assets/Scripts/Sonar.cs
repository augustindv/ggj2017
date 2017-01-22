using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour {

	public GameObject lights;

	public CameraController cameraController;

	public float range = 40f;

	public float speed = 20f;

	public bool active = true;

	public void SetActive(bool active) {
		this.active = active;
		if (active) {
			cameraController.SetSonarMode (true);
		}
		else {
			UpdateLightPosition (0);
			cameraController.SetSonarMode (false);
		}
		lights.SetActive (active);
	}

	void UpdateLightPosition(float x) {
		var p = lights.transform.localPosition;
		lights.transform.localPosition = new Vector3 (x, p.y, p.z);
	}

	float LightPosition() {
		return lights.transform.localPosition.x;
	}

	void Start() {
		SetActive (false);
	}

	void Update() {
		if (active) {
			var movement = speed * Time.deltaTime;
			var newPosition = LightPosition () + movement;
			if (newPosition > range)
				newPosition -= range;

			UpdateLightPosition (newPosition);
		}
	}
}
