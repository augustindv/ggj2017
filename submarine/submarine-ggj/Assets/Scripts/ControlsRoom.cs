using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsRoom : Room {

	// Use this for initialization
	void Start () {
        this.collider = GetComponent<Collider>();
        this.roomName = "controls";
    }

    // Update is called once per frame
    void FixedUpdate () {
    }

    public override IEnumerator useRoom()
    {
        yield return null;
    }
}
