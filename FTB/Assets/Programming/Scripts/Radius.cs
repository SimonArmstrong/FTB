using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour {
	public GameObject flo;
	public static GameObject nearestCloud;

	void Update(){
		if (flo != null) {
			transform.position = flo.transform.position;
			transform.rotation = flo.transform.rotation;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "danger") {
			nearestCloud = other.gameObject;
		}
	}
}
