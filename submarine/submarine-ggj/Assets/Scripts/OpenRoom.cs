using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRoom : MonoBehaviour {

    public Room room;
    // The trigger is inside the room if true
    public bool isInside;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.TAG_CREW_MEMBER)
        {
            if (isInside)
            {
                // Open door
            } else if (!room.isOccupied)
            {
                // Open door
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == Constants.TAG_CREW_MEMBER)
        {
        }
    }
}
