using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	public static float mapSpeed = 1.2f;
	public static float maxMapSpeed = 5;
	//public static List<ParallaxLayer> layers = new List<ParallaxLayer>();
	public int ParallaxLayers;
	float offset;
	public List<GameObject> threats = new List<GameObject>();
	public List<GameObject> coinChunks = new List<GameObject>();
	public static Parallax parallax = new Parallax();

	// Use this for initialization
	void Start () {
		parallax.layers.Clear();
		for (int i = 0; i < ParallaxLayers; i++) {
			parallax.layers.Add (new ParallaxLayer ());
		}
		parallax.InitLayers ();

		//InvokeRepeating ("SpawnObstacle", 10f, 15f);
		//InvokeRepeating ("SpawnCoins", 10f, 15f);
	}

	void SpawnObstacle(){
		Instantiate (threats [Random.Range (0, threats.Count)]);
	}

	void SpawnCoins(){
		Instantiate (coinChunks [Random.Range (0, coinChunks.Count)]);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < parallax.layers.Count; i++) {
			ParallaxLayer layer = parallax.layers [i];
			layer.speed = mapSpeed / (i + 1);
			layer.Offset ();

			for (int j = 0; j < layer.layerObjects.Count; j++) {
				GameObject obj = layer.layerObjects [j];
			} 
		}
		if(mapSpeed < maxMapSpeed)
			mapSpeed += 0.06f * Time.deltaTime;
	}
}
