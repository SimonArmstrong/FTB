using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour {

	public GameObject flo;
	public GameObject moon;

	public void Reset(){
		Map.gameSpeed = 1;
		Map.mapSpeed = 1.2f;
		Flo.distance = 0;
		Flo.currency.cur = 0;
		Flo.isDead = false;
		Flo.stamina.cur = Flo.stamina.max;
		flo.transform.position = new Vector3(-4, 4, 0);
		flo.GetComponent<SpriteRenderer> ().enabled = true;
		flo.GetComponent<Animator>().SetBool("hit", false);	
		moon = Resources.Load<GameObject>("moon");


		for (int i = 0; i < Map.parallax.layers.Count; i++) {
			for (int j = 0; j < Map.parallax.layers [i].layerObjects.Count; j++) {
				Destroy (Map.parallax.layers [i].layerObjects [j]);
			}
			Map.parallax.layers [i].layerObjects.Clear();
		}
		Map.Reset ();
		ShowDeathMenu.show = false;
		Map.parallax.AddToLayer (Instantiate<GameObject>(moon, new Vector3(2, 0, 0), Quaternion.identity), 30);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
