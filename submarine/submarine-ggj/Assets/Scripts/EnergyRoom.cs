using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRoom : Room {

    // Energy to be added over time
    public float energyAdded;
    public float timeElapsed = 2;

    // Use this for initialization
    void Start () {
        this.collider = GetComponent<Collider>();
        this.roomName = Constants.ENERGY;
    }

    // Update is called once per frame
    void Update () {
        Lights();
    }

    public override IEnumerator UseRoom()
    {
        StartCoroutine(UseDoors(doors));
		yield return new WaitUntil (() => !IsUsingDoors ());
		PlaySound ();
        while (submarine.energy < Submarine.ENERGY_MAX)
        {
            yield return new WaitForSeconds(timeElapsed);
            submarine.energy += energyAdded;
        }
		StopSound ();
        this.isUsed = !this.isUsed;
        StartCoroutine(UseDoors(doors));
        yield return null;
    }
}
