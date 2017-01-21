using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRoom : Room {

    // Oxygen to be added over time
    public float oxygenAdded = 1f;
    public float timeElapsed = 2;
    public float duration = 6f;

    private float localTime;

    // Use this for initialization
    void Start() {
        this.collider = GetComponent<Collider>();
        this.roomName = "oxygen";
    }

    // Update is called once per frame
    void Update() {
		
	}

    public override IEnumerator useRoom()
    {
        localTime = 0;
        while (localTime < duration)
        {
            localTime += timeElapsed;
            submarine.oxygen += oxygenAdded;
            yield return new WaitForSeconds(timeElapsed);
        }
        this.isUsed = !this.isUsed;

        yield return null;
    }
}
