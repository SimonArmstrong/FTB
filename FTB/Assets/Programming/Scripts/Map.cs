using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public class ParallaxLayer {
		public float speed;
		public List<GameObject> layerObjects = new List<GameObject> ();

		public void Offset(){
			Vector2 movement = new Vector2 (1, 0);
			for (int i = 0; i < layerObjects.Count; i++) {
				
				layerObjects [i].transform.position -= movement * speed;
			}
		}
	}

	public float mapSpeed = 1.2f;
	public static List<GameObject> mapObjects = new List<GameObject>();
	float offset;
	public List<GameObject> threats = new List<GameObject>();
	public List<GameObject> coinChunks = new List<GameObject>();



	// Use this for initialization
	void Start () {
		mapObjects.Clear();
		mapObjects.AddRange(GameObject.FindGameObjectsWithTag ("map"));
		mapObjects.AddRange(GameObject.FindGameObjectsWithTag ("coin"));
		InvokeRepeating ("SpawnObstacle", 10f, 15f);
		InvokeRepeating ("SpawnCoins", 10f, 15f);
	}

	void SpawnObstacle(){
		Instantiate (threats [Random.Range (0, threats.Count)]);
	}

	void SpawnCoins(){
		Instantiate (coinChunks [Random.Range (0, coinChunks.Count)]);
	}
	
	// Update is called once per frame
	void Update () {
		offset += mapSpeed* Time.deltaTime;
		for (int i = 0; i < mapObjects.Count; i++) {
			mapObjects [i].transform.position -= new Vector3 (mapSpeed, 0, 0) * Time.deltaTime;
		}
		mapSpeed += 0.06f * Time.deltaTime;
	}
}
