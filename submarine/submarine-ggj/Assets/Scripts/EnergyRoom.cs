using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRoom : Room {

    public Submarine submarine;
    // Energy to be added over time
    public float energyAdded;

    // Use this for initialization
    void Start () {
        this.collider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void useRoom()
    {
        submarine.energy += energyAdded;
    }
}
