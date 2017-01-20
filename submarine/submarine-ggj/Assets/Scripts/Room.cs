using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour {

    public static string TAG_CHARACTER = "Character";

    [HideInInspector]
    public Collider collider;
    // Boolean to know if the room is occupied by a character
    public bool isOccupied;
    // Boolean to know if the room is disabled/destroyed and needs reparation
    public bool isDisabled;
    public Character character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == TAG_CHARACTER)
        {
            isOccupied = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == TAG_CHARACTER)
        {
            isOccupied = false;
        }
    }

    public abstract void useRoom();
}
