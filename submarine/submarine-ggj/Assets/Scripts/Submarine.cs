using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

    public static readonly float HP_MAX = 100;
    public static readonly float ENERGY_MAX = 100;
    public static readonly float OXYGEN_MAX = 100;

    // HP of the submarine
    public float hp;
    // Speed of the submarine
    public float horizontalSpeed;
    public float verticalSpeed = 0.5f;
    // Energy of the submarine
    public float energy;
    // Oxygen of the submarine
    public float oxygen;

	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Move up and down submarine
    public void Move(float movement)
    {
        transform.Translate(new Vector2(movement * verticalSpeed, 0));
    }
}
