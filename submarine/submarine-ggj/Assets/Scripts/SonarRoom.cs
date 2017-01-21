using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarRoom : Room {

    public float duration = 5;

    // Use this for initialization
    void Start () {
        this.collider = GetComponent<Collider>();
        this.roomName = Constants.SONAR;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override IEnumerator UseRoom()
    {
        StartCoroutine(UseDoors());
        sonar.SetActive(!sonar.active);
        yield return new WaitForSeconds(duration);
        this.isUsed = !this.isUsed;
        sonar.SetActive(!sonar.active);
        StartCoroutine(UseDoors());
    }
}
