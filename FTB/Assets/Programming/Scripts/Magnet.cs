using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "coin") {
			other.transform.position = Vector3.Lerp (other.transform.position, transform.position, Time.deltaTime * Map.gameSpeed * 2);
			if (Vector3.Distance(other.transform.position, transform.position) <= 1) {
				Map.parallax.RemoveItem (other.gameObject);
				Destroy (other.gameObject);
				Flo.currency += other.gameObject.GetComponent<Coin>().value;
				Flo.AS.clip = other.gameObject.GetComponent<Coin> ().sfx;
				Flo.AS.Play ();
			}
		}
	}
}
