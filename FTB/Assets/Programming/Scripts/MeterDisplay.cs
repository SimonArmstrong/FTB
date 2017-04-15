using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterDisplay : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		text.text = Flo.distance.ToString("0.00");
	}
}
