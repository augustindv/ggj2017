using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRoom : Room {

    public Submarine submarine;
    // Oxygen to be added over time
    public float oxygenAdded;

    // Use this for initialization
    void Start() {
        this.collider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update() {
		
	}

    public override void useRoom()
    {
        submarine.oxygen += oxygenAdded;
    }
}
