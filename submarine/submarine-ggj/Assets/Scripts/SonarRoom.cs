using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarRoom : Room {

    // Use this for initialization
    void Start () {
        this.collider = GetComponent<Collider>();
        this.roomName = Constants.SONAR;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override IEnumerator UseRoom()
    {
        StartCoroutine(UseDoors());
        yield return null;
    }
}
