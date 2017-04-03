using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour {
	public bool DestroyNow = false;
	void FixedUpdate(){
		if (DestroyNow) {
			Destroy (gameObject);
		}
	}
}
