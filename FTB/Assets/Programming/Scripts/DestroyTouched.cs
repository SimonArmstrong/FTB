using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTouched : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Flo.isDead = true;
		} else {
			Map.parallax.RemoveItem (other.gameObject);
			Destroy (other.gameObject);
		}
	}
}
