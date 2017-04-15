using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTouched : MonoBehaviour {
	public string OnlyDestroyItemsWithTag = "";
	public string DontDestroyItemsWithTag = "";
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag != DontDestroyItemsWithTag) {
			if (other.gameObject.tag == "Player") {
				Flo.isDead = true;
			} else {
				Map.parallax.RemoveItem (other.gameObject);
				Destroy (other.gameObject);
			}
		}

	}
}
