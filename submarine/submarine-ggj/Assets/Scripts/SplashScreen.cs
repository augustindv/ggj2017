using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SplashScreen : MonoBehaviour {

	public void StartGame() {
		SceneManager.LoadScene ("level_design_test");
	}
}
