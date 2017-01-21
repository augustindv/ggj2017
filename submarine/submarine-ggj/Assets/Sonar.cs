using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour {

	public GameObject lights;

	public Camera mainCamera;

	public Transform sonarCameraPosition;

	public float cameraZoomSpeed = 5;

	public float range = 40f;

	public float speed = 20f;

	private bool active = true;

	private Vector3 defaultCameraPosition;

	private Coroutine cameraMovement = null;

	public void SetActive(bool active) {
		this.active = active;
		if (active) {
			MoveCamera (sonarCameraPosition.position);
		}
		else {
			UpdateLightPosition (0);
			MoveCamera (defaultCameraPosition);
		}
		lights.SetActive (active);
	}

	void MoveCamera(Vector3 target) {
		if (cameraMovement != null){
			StopCoroutine (cameraMovement); 
			cameraMovement = null;
		}
		cameraMovement = StartCoroutine (CameraMovement (target));
	}

	IEnumerator CameraMovement(Vector3 target) {
		while (Vector3.Distance (mainCamera.transform.position, target) > speed * Time.deltaTime) {
			var direction = (target - mainCamera.transform.position).normalized;
			mainCamera.transform.Translate (direction * speed * Time.deltaTime);
			yield return new WaitForEndOfFrame ();
		}
		mainCamera.transform.position = target;
		yield return null;
	}

	void UpdateLightPosition(float x) {
		var p = lights.transform.localPosition;
		lights.transform.localPosition = new Vector3 (x, p.y, p.z);
	}

	float LightPosition() {
		return lights.transform.localPosition.x;
	}

	void Start() {
		defaultCameraPosition = mainCamera.transform.position;
		SetActive (false);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Q))
			SetActive (!active);
		
		if (active) {
			var movement = speed * Time.deltaTime;
			var newPosition = LightPosition () + movement;
			if (newPosition > range)
				newPosition -= range;

			UpdateLightPosition (newPosition);
		}
	}
}
