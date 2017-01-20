using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsRoom : Room {

    public Submarine submarine;
    // Speed modifier of the submarine movement
    private float movementSpeed = 0.5f;
    private float movement;

	// Use this for initialization
	void Start () {
        this.collider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Vertical");
    }

    public override void useRoom()
    {
        submarine.Move(movement * movementSpeed);
    }
}
