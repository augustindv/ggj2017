using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRoom : Room {
    private static string ROOM_NAME = "oxygen";

    // Oxygen to be added over time
    public float oxygenAdded;
    public float duration;

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
            localTime += Time.deltaTime;
            submarine.oxygen += oxygenAdded;
        }

        yield return null;
    }
}
