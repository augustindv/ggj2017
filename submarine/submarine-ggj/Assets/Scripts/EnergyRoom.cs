using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRoom : Room {

    // Energy to be added over time
    public float energyAdded;
    public float duration;

    private float localTime;

    // Use this for initialization
    void Start () {
        this.collider = GetComponent<Collider>();
        this.roomName = "energy";
    }

    // Update is called once per frame
    void Update () {
		
	}

    public override IEnumerator useRoom()
    {
        localTime = 0;
        while (localTime < duration)
        {
            localTime += Time.deltaTime;
            submarine.energy += energyAdded;
        }
   
        yield return null;
    }
}
