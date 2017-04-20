using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDeathMenu : MonoBehaviour {

	public static bool show = false;
	private Vector2 start;
	private RectTransform rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
		start = rt.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (show) {
			if (rt.localPosition.y <= 90) {
				rt.localPosition = rt.localPosition + new Vector3 (0, 2000, 0) * Time.deltaTime;
			}
			//Debug.Log ("OPEN");
		} else {
			rt.localPosition = start;
		}
	}
}
