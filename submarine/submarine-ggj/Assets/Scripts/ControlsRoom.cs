using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsRoom : Room {

	// Use this for initialization
	void Start () {
        this.collider = GetComponent<Collider>();
        this.roomName = Constants.CONTROLS;
    }

    // Update is called once per frame
    void FixedUpdate () {
    }

    public override IEnumerator UseRoom()
    {
        StartCoroutine(UseDoors());
        yield return null;
    }
}
