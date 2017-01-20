using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {

    // HP of the submarine
    public float hp;
    // Speed of the submarine
    public float speed;
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
        transform.Translate(new Vector2(movement, 0));
    }
}
