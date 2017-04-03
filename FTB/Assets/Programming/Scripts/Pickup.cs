using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	float value = 1f;


	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			gameObject.SetActive (false);
			//increment player coins
			Player.currency += value;
		}
	}

	void Awake(){
		//Map.mapObjects.Add (gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
