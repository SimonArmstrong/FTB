using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	public static float mapSpeed = 1.2f;
	public static float gameSpeed = 1.0f;
	public static float maxMapSpeed = 20;
	private float lastSpeed;
	private bool paused = false;
	//public static List<ParallaxLayer> layers = new List<ParallaxLayer>();
	public int ParallaxLayers;
	float offset;
	public List<GameObject> threats = new List<GameObject>();
	public List<GameObject> coinChunks = new List<GameObject>();
	public static Parallax parallax = new Parallax();
	public GameObject moon;
	public static bool isInGame = true;

	public void Pause(){
		paused = !paused;
	}

	public static void Reset(){		
		isInGame = true;
	}

	// Use this for initialization
	void Start () {
		parallax.layers.Clear();
		for (int i = 0; i < ParallaxLayers; i++) {
			parallax.layers.Add (new ParallaxLayer ());
		}
		Map.parallax.InitLayers ();

		moon = Resources.Load<GameObject>("moon");
		parallax.AddToLayer (Instantiate<GameObject>(moon, new Vector3(2, 0, 0), Quaternion.identity), 30);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
		}

		if (paused) {
			gameSpeed = 0;
		} else {
			gameSpeed = 1;
		}

		for (int i = 0; i < parallax.layers.Count; i++) {
			ParallaxLayer layer = parallax.layers [i];
			layer.speed = mapSpeed / (i + 1);
			layer.Offset ();

			for (int j = 0; j < layer.layerObjects.Count; j++) {
				GameObject obj = layer.layerObjects [j];
			} 
		}

		Flo.distance += (mapSpeed * Time.deltaTime * gameSpeed) * 0.1f;

		if(mapSpeed < maxMapSpeed && gameSpeed > 0)
			mapSpeed += 0.1f * Time.deltaTime * gameSpeed;
		
		if(gameSpeed == 1)
			lastSpeed = mapSpeed;
		else if (Flo.stamina.cur > 0)
			mapSpeed = lastSpeed + (mapSpeed * gameSpeed);
		
	}
}
