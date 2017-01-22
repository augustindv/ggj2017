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
        StartCoroutine(UseDoors());
        while (submarine.energy < Submarine.ENERGY_MAX && !needsRepair)
        {
            yield return new WaitForSeconds(timeElapsed);
            submarine.energy += energyAdded;
        }
        this.isUsed = !this.isUsed;
        StartCoroutine(UseDoors());
        yield return null;
    }
}
