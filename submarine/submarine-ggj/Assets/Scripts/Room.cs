using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour {

    [HideInInspector]
    public Collider collider;
    // Boolean to know if the room is occupied by a crew member
    public bool isOccupied;
    // Boolean to know if the room is ised by a crew member
    public bool isUsed;
    // Boolean to know if the room is destroyed and needs reparation
    public bool needsRepair;
    // Boolean to know if the room is disabled because not enough ressource
    public bool isDisabled;
    // Boolean to know if the doors are closed
    public bool doorsClosed = false;
    public Submarine submarine;
    public Sonar sonar;
    [HideInInspector]
    public string roomName;
    [HideInInspector]
    public CrewMember crewMember;

    public GameObject[] doors;

    public float timeElapsedRepair = 2;
    public float durationRepair = 6f;

    private float localTimeRepair;

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
            isOccupied = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == Constants.TAG_CREW_MEMBER)
        {
            isOccupied = false;
        }
    }

    public string GetRoomName()
    {
        return this.roomName;
    }

    public IEnumerator RepairRoom()
    {
        localTimeRepair = 0;
        while (localTimeRepair < durationRepair)
        {
            localTimeRepair += timeElapsedRepair;
            yield return new WaitForSeconds(timeElapsedRepair);
        }
        this.needsRepair = false;
        this.isUsed = !this.isUsed;

        yield return null;
    }

    public IEnumerator UseDoors()
    {
		if (doors.Length == 0)
			yield return null;
		
        float lerpTime = 1;
        float startTime = Time.time;

        if (doorsClosed)
        {
            doorsClosed = !doorsClosed;
			while (doors[0] != null && Mathf.Round(doors[0].transform.localScale.y * 100f) / 100f > 0 && !doorsClosed)
            {
                float timeProgressed = (Time.time - startTime) / lerpTime;
                foreach (var door in doors)
                {
                    Vector3 tmpVec = Vector3.Lerp(door.transform.localScale, new Vector3(1, 0, 1), timeProgressed);
                    door.transform.localScale = new Vector3(tmpVec.x, Mathf.Round(tmpVec.y * 100f) / 100f, 1);
                }
                yield return new WaitForFixedUpdate();
            }
        } else
        {
            doorsClosed = !doorsClosed;
			while (doors[0] != null && Mathf.Round(doors[0].transform.localScale.y * 100f) / 100f < 1 && doorsClosed)
            {
                float timeProgressed = (Time.time - startTime) / lerpTime;
                foreach (var door in doors)
                {
                    Vector3 tmpVec = Vector3.Lerp(door.transform.localScale, new Vector3(1, 1, 1), timeProgressed);
                    door.transform.localScale = new Vector3(tmpVec.x, Mathf.Round(tmpVec.y * 100f) / 100f, 1);
                }
                yield return new WaitForFixedUpdate();
            }
        }
        yield return null;
    }

    public abstract IEnumerator UseRoom();
}
