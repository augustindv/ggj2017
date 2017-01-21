using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineStatus : MonoBehaviour {

	public Slider hpSlider;
	public Slider energySlider;
	public Slider oxygenSlider;

	public Submarine submarine;

	void SetSlider(Slider slider, float current, float max) {
		slider.value = Mathf.Max(0, current) / max;
	}

	void Update () {
		SetSlider (hpSlider, submarine.hp, Submarine.HP_MAX);
		SetSlider (energySlider, submarine.energy, Submarine.ENERGY_MAX);
		SetSlider (oxygenSlider, submarine.oxygen, Submarine.OXYGEN_MAX);
	}
}
