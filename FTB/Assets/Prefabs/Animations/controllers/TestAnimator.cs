using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimator : MonoBehaviour {

	public Animator animator;
	public Rigidbody2D rb;
	public float maxForce;
	public float maxFallSpeed;

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
		rb.AddForce (Vector2.up * 300);
	}

	// Update is called once per frame
	void Update () {
		bool flap = Input.GetMouseButtonDown (0);
		if (flap) {
			from = transform.position;
			Flap (from + Vector2.up);
		}
		if (rb.velocity.magnitude > maxForce) {
			rb.velocity = rb.velocity.normalized * maxForce;
		}
		animator.SetBool ("flap", flap);
	}
}
