using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flo : MonoBehaviour {

	public Animator animator;
	public Rigidbody2D rb;
	public float rotationAmount;
	public float maxForce;
	public float maxFallSpeed;
	public static float currency;
	private float flapPower;
	public GameObject trail;

	public float flapForce;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	Vector2 from = new Vector2();
	//Vector2 to;
	void Flap(Vector2 to){
		if (rb.velocity.magnitude > maxForce) {
			rb.velocity = rb.velocity.normalized * maxForce;
		}
		rb.AddForce (Vector2.up * flapForce);
	}

	// Update is called once per frame
	void Update () {
		if (Map.gameSpeed <= 0) {
			rb.simulated = false;
		} else {
			rb.simulated = true;
		}
		bool flap = Input.GetMouseButtonDown (0);
		if (flap) {
			from = transform.position;
			Flap (from + Vector2.up);
			flapPower = 2;
		}
		if (rb.velocity.magnitude > maxForce) {
			rb.velocity = rb.velocity.normalized * maxForce;
		}

		if(flapPower > 1) flapPower -= Time.deltaTime;

		Vector3 eulerVeloityTranslation = new Vector3 (0, 0, rb.velocity.y * rotationAmount);
		transform.rotation = Quaternion.Euler(eulerVeloityTranslation);
		animator.SetBool ("flap", flap);
		animator.SetFloat("flapPower", flapPower);
		trail.transform.localScale = new Vector3 (0.1f * Map.mapSpeed, 1, 1);

		maxForce *= Map.gameSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "coin") {
			for (int i = 0; i < Map.parallax.layers.Count; i++) {
				for(int j = 0; j < Map.parallax.layers[i].layerObjects.Count; j++){
					if (ReferenceEquals(other.gameObject, Map.parallax.layers [i].layerObjects [j])) {
						Map.parallax.layers [i].layerObjects.RemoveAt(j);
						break;
					}
				}
			}

			Destroy (other.gameObject);
		}
	}
}
