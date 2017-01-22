using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform sonarPosition;

	public float distanceToCharacters;

	public float zoomSpeed = 5;

	public Camera mainCamera;

	bool sonarMode = false;

	Coroutine cameraMovement = null;

	Transform currentTarget;

	public void SetTarget(Transform target) {
		currentTarget = target;
	}

	public void SetSonarMode(bool sonarMode) {
		if (this.sonarMode != sonarMode) {
			this.sonarMode = sonarMode;
			if (sonarMode)
				MoveCamera (sonarPosition);
			else
				MoveCamera (currentTarget);
		}
	}
		
	void MoveCamera(Transform target) {
		if (cameraMovement != null){
			StopCoroutine (cameraMovement); 
			cameraMovement = null;
		}
		cameraMovement = StartCoroutine (CameraMovement (target));
	}

	IEnumerator CameraMovement(Transform target) {
		while (Vector3.Distance (mainCamera.transform.position, target.position) > zoomSpeed * Time.deltaTime) {
			var direction = (target.position - mainCamera.transform.position).normalized;
			mainCamera.transform.Translate (direction * zoomSpeed * Time.deltaTime);
			yield return new WaitForEndOfFrame ();
		}
		mainCamera.transform.position = target.position;
		cameraMovement = null;
		yield return null;
	}

	void Update () {
		if (!sonarMode && currentTarget != null && cameraMovement == null)
			mainCamera.transform.position = currentTarget.position;
		
	}
}
