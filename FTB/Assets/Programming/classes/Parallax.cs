using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Parallax {
	public List<ParallaxLayer> layers = new List<ParallaxLayer> ();
	public void InitLayers(){
		for (int i = 0; i < layers.Count; i++) {
			layers [i].layerID = i;
		}
	}
	public void AddToLayer(GameObject obj, int layer){
		layers [layer].layerObjects.Add (obj);
	}
}
