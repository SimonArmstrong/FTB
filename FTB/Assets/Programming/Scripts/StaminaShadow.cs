using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaShadow : MonoBehaviour {
	public Slider slider;
	Slider mySlider;

	void Start(){
		mySlider = GetComponent<Slider> ();
	}
	void Update(){
		if(mySlider.value > slider.value)
			mySlider.value -= 20 * Time.deltaTime;	

		if (slider.value > mySlider.value)
			mySlider.value = slider.value;
	}
}
