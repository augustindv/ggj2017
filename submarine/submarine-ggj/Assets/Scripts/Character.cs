using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public Room room;

	// Use this for initialization
	void Start () {
        //room = new ControlsRoom();
	}
	
	// Update is called once per frame
	void Update () {
        room.useRoom();
	}
}
