using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsRoom : Room {

	public CameraController cameraController;

	void Start () {
        this.collider = GetComponent<Collider>();
        this.roomName = Constants.CONTROLS;
    }

    void FixedUpdate () {
        Lights();
    }

    public override IEnumerator UseRoom()
    {
		if (submarine.HasEnergy(1) || isUsed)
			StartCoroutine(UseDoors(doors));

		yield return new WaitUntil (() => !IsUsingDoors ());
		cameraController.SetSonarMode (true);

        yield return null;
	}

	public override IEnumerator StopUsingRoom() {
		yield return new WaitUntil (() => !IsUsingDoors ());
		cameraController.SetSonarMode (false);
		yield return null;

	}
}
