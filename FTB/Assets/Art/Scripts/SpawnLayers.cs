using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLayers : MonoBehaviour {
	public List<GameObject> Background = new List<GameObject>();
	public List<GameObject> MidBackground = new List<GameObject>();
	public List<GameObject> Main = new List<GameObject> ();
	public List<GameObject> coins = new List<GameObject> ();
	public float timeOffset;
	private float time;
	void Start(){
		time = timeOffset;
	}
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime * Map.gameSpeed;
		if (time <= 0) {
			int random_cloud = Random.Range (0, 3);
			Vector3 randomYPosition = new Vector3 (transform.position.x,
				Random.Range(-5, 5));
			Vector3 randomRotation = new Vector3 (
				0, 0,
				Random.Range(0, 4) * 90
			);
			Vector3 randomHeight = new Vector3 (transform.position.x, Random.Range(-5, 5), 0);
			if(Main.Count > 0) Map.parallax.AddToLayer (Instantiate<GameObject> (Main[Random.Range(0, Main.Count)], randomYPosition, Quaternion.Euler(randomRotation)), 0);
			if(coins.Count > 0) Map.parallax.AddToLayer (Instantiate<GameObject> (coins[0], randomHeight, Quaternion.identity), 0);
			if(MidBackground.Count > 0) Map.parallax.AddToLayer (Instantiate<GameObject> (MidBackground [random_cloud], randomYPosition, Quaternion.identity), 2);
			if(Background.Count > 0) Map.parallax.AddToLayer (Instantiate<GameObject> (Background [Random.Range(0, Background.Count)], transform.position, Quaternion.identity), 3);
			time = timeOffset;
		}
		if(timeOffset > 1)
			timeOffset -= 0.1f * Time.deltaTime * Map.gameSpeed;
	}
}
