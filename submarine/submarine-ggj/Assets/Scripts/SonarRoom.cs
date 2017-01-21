using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarRoom : Room {
    private static string ROOM_NAME = "sonar";

    // Use this for initialization
    void Start () {
        this.collider = GetComponent<Collider>();
        this.roomName = "sonar";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override IEnumerator useRoom()
    {
        yield return null;
    }
}
