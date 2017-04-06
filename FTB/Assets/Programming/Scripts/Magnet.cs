using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {

	public GameObject flo;

	void Update(){
		if (flo != null) {
			transform.position = flo.transform.position;
			transform.rotation = flo.transform.rotation;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "coin") {
			other.transform.position = Vector3.Lerp (other.transform.position, transform.position, Time.deltaTime * Map.gameSpeed * Map.mapSpeed);
			if (Vector3.Distance(other.transform.position, transform.position) <= 1) {
				if (!Flo.onDeathSequence) {
					Map.parallax.RemoveItem (other.gameObject);
					Destroy (other.gameObject);
					Flo.currency += other.gameObject.GetComponent<Coin> ().value;
					Flo.AS.clip = other.gameObject.GetComponent<Coin> ().sfx;
					//Flo.stamina.cur += 3;
					Flo.AS.Play ();
				}
			}
		}
	}
}
