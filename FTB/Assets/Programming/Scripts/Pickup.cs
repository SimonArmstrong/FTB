using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	float value = 1f;
	public GameObject pickupParticle;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//Instantiate<GameObject> (pickupParticle, transform.position, Quaternion.identity);
			//Destroy (gameObject);
			//increment player coins
			Flo.currency += value;
		}
	}

	void OnDestroy(){
		for (int i = 0; i < Map.parallax.layers [0].layerObjects.Count; i++) {
			if(Map.parallax.layers[0].layerObjects[i] == gameObject)
				Map.parallax.GetLayer (0).layerObjects.RemoveAt (i);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
