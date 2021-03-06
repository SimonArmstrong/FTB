﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParallaxLayer {
	public float speed;
	public int layerID;
	public List<GameObject> layerObjects = new List<GameObject> ();

	public void Offset(){
		Vector3 movement = new Vector3 (1 * Map.gameSpeed, 0 , 0);
		for (int i = 0; i < layerObjects.Count; i++) {
			for (int j = 0; j < layerObjects [i].GetComponentsInChildren<SpriteRenderer> ().Length; j++) {
				layerObjects [i].GetComponentsInChildren<SpriteRenderer> () [j].sortingOrder = -(layerID);
			}
			layerObjects [i].transform.position -= movement * speed * Time.deltaTime;
		}
	}
}
