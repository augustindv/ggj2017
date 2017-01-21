using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonMenu : MonoBehaviour {

	public Button[] buttons;

	Toggle toggle;

	float delay = 0.3f;

	float lastTime = 0;

	void Start () {
		toggle = new Toggle (buttons.Length, 0);
	}

	void Update () {
		float vertical = Input.GetAxis ("Vertical");
		if (vertical > 0)
			toggle.Previous ();
		else if (vertical < 0)
			toggle.Next ();

		Button button = buttons [toggle.Current ()];
		if (Input.GetButtonDown ("Fire1")) {
			button.onClick.Invoke ();
		}
		if (vertical > 0 || vertical < 0 && lastTime + delay < Time.time) {
			lastTime = Time.time;
			EventSystem.current.SetSelectedGameObject(button.gameObject, new BaseEventData(EventSystem.current));
		}
	}
}
