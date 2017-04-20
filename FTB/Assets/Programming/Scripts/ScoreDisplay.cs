using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	Text text;

	public bool showAll = false;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(showAll)
			text.text = Flo.currency.max.ToString();
		else
			text.text = Flo.currency.cur.ToString();
	}
}
