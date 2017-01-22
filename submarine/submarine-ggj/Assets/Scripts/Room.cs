using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Room : MonoBehaviour {

	public string helpText;

	public Text helpDisplay;

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

    public Light[] lights;

    public float timeElapsedRepair = 2;
    public float durationRepair = 6f;

    private float localTimeRepair;
    private float waitingTimeBlink = 0.5f;

    public bool isBlinking = false;
    public bool lightGreen = true;

	private int usingDoors = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Lights()
    {
        if (needsRepair && !isBlinking)
        {
            lightGreen = false;
            foreach (var light in lights)
            {
                light.color = new Color(255, 0, 0);
                light.intensity = 1;
                light.range = 2;
                light.bounceIntensity = 0;
                StartCoroutine(Blink(light));
            }
        }
        else if (!isBlinking && !lightGreen)
        {
            foreach (var light in lights)
            {
                light.intensity = 5;
                light.range = 3;
                light.bounceIntensity = 3;
                light.color = new Color(0, 65 / 255, 0, 1);
                light.enabled = true;
            }
            lightGreen = true;
        }
    }

    public IEnumerator Blink(Light light)
    {
        isBlinking = true;
        while (needsRepair)
        {
            yield return new WaitForSeconds(waitingTimeBlink);
            light.enabled = !(light.enabled);
        }
        isBlinking = false;
    }

	void ShowHelpText() {
		helpDisplay.gameObject.SetActive (true);
		helpDisplay.text = helpText;
	}

	void HideHelpText() {
		helpDisplay.gameObject.SetActive (false);
		helpDisplay.text = "";
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.TAG_CREW_MEMBER)
        {
			ShowHelpText ();
            isOccupied = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == Constants.TAG_CREW_MEMBER)
        {
			HideHelpText ();
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

	public IEnumerator UseDoors(GameObject[] doors)
    {
		if (doors.Length == 0)
			yield return null;

		usingDoors += 1;
		
        float lerpTime = 1;
        float startTime = Time.time;

        if (doorsClosed)
        {
            doorsClosed = !doorsClosed;
			while (doors.Length > 0 && doors[0] != null && Mathf.Round(doors[0].transform.localScale.y * 100f) / 100f > 0 && !doorsClosed)
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
			while (doors.Length > 0 && doors[0] != null && Mathf.Round(doors[0].transform.localScale.y * 100f) / 100f < 1 && doorsClosed)
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

		usingDoors -= 1;

        yield return null;
    }

	public bool IsUsingDoors() {
		return usingDoors > 0;
	}

    public abstract IEnumerator UseRoom();

	public virtual IEnumerator StopUsingRoom() {
		yield return null;
	}
}
