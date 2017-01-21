using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour {

    public static string TAG_CREW_MEMBER = "CrewMember";

    [HideInInspector]
    public Collider collider;
    // Boolean to know if the room is occupied by a crew member
    public bool isOccupied;
    // Boolean to know if the room is ised by a crew member
    public bool isUsed;
    // Boolean to know if the room is disabled/destroyed and needs reparation
    public bool isDisabled;
    public Submarine submarine;
    [HideInInspector]
    public string roomName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == TAG_CREW_MEMBER)
        {
            isOccupied = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == TAG_CREW_MEMBER)
        {
            isOccupied = false;
        }
    }

    public string getRoomName()
    {
        return this.roomName;
    }

    public abstract IEnumerator useRoom();
}
