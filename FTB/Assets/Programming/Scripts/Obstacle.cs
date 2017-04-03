using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public bool isTouched;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			isTouched = true;
		}
	}

	// Use this for initialization
	void Start () {
		isTouched = false;
	}

	void Awake(){
		//Map.mapObjects.Add (gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
