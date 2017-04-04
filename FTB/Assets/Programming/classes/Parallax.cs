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

	public void RemoveItem(GameObject obj){
		for (int i = 0; i < Map.parallax.layers.Count; i++) {
			for(int j = 0; j < Map.parallax.layers[i].layerObjects.Count; j++){
				if (ReferenceEquals(obj, Map.parallax.layers [i].layerObjects [j])) {
					Map.parallax.layers [i].layerObjects.RemoveAt(j);
					break;
				}
			}
		}
	}

	public ParallaxLayer GetLayer(int layer){
		return layers [layer];
	}
}
