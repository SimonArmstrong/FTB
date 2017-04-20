using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloParticles : MonoBehaviour {
	public GameObject featherParticle;

	// Update is called once per frame
	void Update () {
		bool flap = Input.GetMouseButtonDown (0);
		if (flap && !Flo.isDead) {
			float randomX, randomY, randomZ;
			randomX = Random.Range (-0.5f, 0.5f);
			randomY = Random.Range (-0.2f, 0.2f);
			randomZ = Random.Range (-180, 180);
			Vector3 randomOffset = new Vector3(randomX, randomY, 0);
			Vector3 randomRotation = new Vector3 (0, 0, randomZ);
			Instantiate<GameObject> (featherParticle, (transform.position - new Vector3(0.6f, 0, 0)) + randomOffset, Quaternion.Euler(randomRotation));
		}
	}
}
