using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLayers : MonoBehaviour {
	public List<GameObject> bgTile = new List<GameObject>();
	public List<GameObject> clouds = new List<GameObject>();
	public float timeOffset;
	private float time;
	void Start(){
		time = timeOffset;
	}
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			int random_cloud = Random.Range (0, 3);
			Vector3 randomYPosition = new Vector3 (transform.position.x,
				Random.Range(-5, 5));
			Map.parallax.AddToLayer (Instantiate<GameObject> (clouds [random_cloud], randomYPosition, Quaternion.identity), 2);
			Map.parallax.AddToLayer (Instantiate<GameObject> (bgTile [Random.Range(0, 2)], transform.position, Quaternion.identity), 3);
			time = timeOffset;
		}
		if(timeOffset > 1)
			timeOffset -= Map.mapSpeed;
	}
}
