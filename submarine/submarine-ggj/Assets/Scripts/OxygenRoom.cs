using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRoom : Room {

    // Oxygen to be added over time
    public float oxygenAdded = 1f;
    public float timeElapsed = 2;

    // Use this for initialization
    void Start() {
        this.collider = GetComponent<Collider>();
        this.roomName = Constants.OXYGEN;
    }

    // Update is called once per frame
    void Update() {
        Lights();
    }

    public override IEnumerator UseRoom()
    {
		StartCoroutine(UseDoors(doors));
		yield return new WaitUntil (() => !IsUsingDoors ());
		PlaySound ();
		while (submarine.oxygen < Submarine.OXYGEN_MAX && !needsRepair)
        {
            yield return new WaitForSeconds(timeElapsed);
            submarine.oxygen += oxygenAdded;
        }
		StopSound ();
        this.isUsed = !this.isUsed;
        StartCoroutine(UseDoors(doors));
        yield return null;
    }
}
