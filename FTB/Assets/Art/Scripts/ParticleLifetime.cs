using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifetime : MonoBehaviour {
	public float time;
	public bool fade;
	public Vector2 direction;
	private Color startColor;
	private float a_time;
	// Use this for initialization
	void Start () {
		a_time = time;
		startColor = GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update () {
		a_time -= Time.deltaTime;
		if(a_time <= 0){
			Destroy (gameObject);
			a_time = time;
		}
		if (fade) {
			Color newColor = new Color(startColor.r, startColor.g, startColor.b, startColor.a * a_time);
			GetComponent<SpriteRenderer> ().color = newColor;
		}
		transform.position = new Vector2 (transform.position.x - Map.mapSpeed * Time.deltaTime, transform.position.y - a_time * Time.deltaTime);
	}
}
