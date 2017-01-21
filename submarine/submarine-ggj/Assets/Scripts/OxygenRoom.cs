﻿using System;
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
		
	}

    public override IEnumerator UseRoom()
    {
        StartCoroutine(UseDoors());
        while (submarine.oxygen < Submarine.OXYGEN_MAX)
        {
            yield return new WaitForSeconds(timeElapsed);
            submarine.oxygen += oxygenAdded;
        }
        this.isUsed = !this.isUsed;
        StartCoroutine(UseDoors());
        yield return null;
    }
}
