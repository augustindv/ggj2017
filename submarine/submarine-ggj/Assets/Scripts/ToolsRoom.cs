using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsRoom : Room {

    // Some tool is available to be used
    private bool toolAvailable;

	// Use this for initialization
	void Start () {
        this.collider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void useRoom()
    {
    }
}
