﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flo : MonoBehaviour {

	[System.Serializable]
	public struct Stat{
		public float cur;
		public float max;
	}
	public Animator animator;
	public Rigidbody2D rb;
	public float rotationAmount;
	public float maxForce;
	public float maxFallSpeed;
	public static Stat currency;
	public static float distance;
	private float flapPower;
	public GameObject trail;
	[HideInInspector]
	public static AudioSource AS;
	public AudioSource uiAS;
	public static bool onDeathSequence;
	public static bool isDead;

	public List<Sprite> initialSkinFrames = new List<Sprite> ();

	public float frame;
	public static Skin skin;
	public static List<Sprite> skinFrames = new List<Sprite> ();

	public float flapForce;

	public bool demo;
	private float hopTimer;
	private float hopTimerOffset = 0.3f;

	public static float mps;
	public SpriteRenderer sr;

	public static Stat stamina;

	public void MakeFrame(Sprite sprite){
		sr.sprite = sprite;
	}

	void OnPause(){
		Map.gameSpeed = 0;
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		AS = GetComponents<AudioSource> ()[0];
		uiAS = GetComponents<AudioSource> ()[1];
		sr = GetComponent<SpriteRenderer> ();

		hopTimer = hopTimerOffset;

		stamina.max = 100;
		stamina.cur = stamina.max;

		Screen.autorotateToLandscapeLeft = true;
		//currency.cur = 1000;
	}

	Vector2 from = new Vector2();
	//Vector2 to;
	void Flap(Vector2 to){
		if (rb.velocity.magnitude > maxForce) {
			rb.velocity = (rb.velocity.normalized * maxForce) * Map.gameSpeed;
		}
		rb.AddForce (Vector2.up * flapForce);
	}
	float t = 1;
	// Update is called once per frame
	void Update () {
		//MakeFrame (skinFrames [(int)frame]);
		hopTimer -= Time.deltaTime * Map.gameSpeed;

		mps = Map.mapSpeed * 0.1f;

		if (Map.gameSpeed <= 0) {
			rb.simulated = false;
		} else {
			rb.simulated = true;
		}

		bool flap = Input.GetMouseButtonDown (0);
		if (demo) {
			if (transform.position.y < 0 && hopTimer < 0) {
				flap = true;
				hopTimer = hopTimerOffset;
			} else if (transform.position.y > -3 && hopTimer < 0) {
				flap = false;
			}
		}
		if (!onDeathSequence) {
			if (flap && stamina.cur > 0) {
				from = transform.position;
				Flap (from + Vector2.up);
				flapPower = 2;
				//stamina.cur -= 2;
			}
		}
		if (rb.velocity.magnitude > maxForce) {
			rb.velocity = (rb.velocity.normalized * maxForce) * Map.gameSpeed;
		}

		if (stamina.cur > stamina.max)
			stamina.cur = stamina.max;

		if(flapPower > 1) flapPower -= Time.deltaTime;

		Vector3 eulerVeloityTranslation = new Vector3 (0, 0, rb.velocity.y * rotationAmount);
		transform.rotation = Quaternion.Euler(eulerVeloityTranslation);
		animator.SetBool ("flap", flap);
		animator.SetFloat("flapPower", flapPower);
		trail.transform.localScale = new Vector3 (0.1f * Map.mapSpeed, 1, 1);


		if (stamina.cur <= 0) {
			t -= Time.deltaTime;
			Map.gameSpeed = 0;
			if (t <= 0) {
				Map.gameSpeed = 1;
			}
			Map.mapSpeed = 0;
		}
		//maxForce *=

		if (isDead) {
			Map.mapSpeed = 0;
			Map.gameSpeed = 0;
			rb.simulated = false;
			GetComponent<SpriteRenderer> ().enabled = false;
			onDeathSequence = false;
			//ShowDeathMenu.show = true;
			Map.isInGame = false;
			AddUpCoins ();
		}

	}

	float aup_t = 0.01f;
	public void AddUpCoins(){
		aup_t -= Time.deltaTime;
		int total = (int)currency.cur;
		if (aup_t < 0) {
			if (currency.cur > 0) {
				//uiAS.pitch += 0.01f;
				//uiAS.Play ();
				currency.max++;
				currency.cur--;
			}
			aup_t = 0.01f;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "danger") {
			// Dead
			onDeathSequence = true;
			Flo.stamina.cur = 0;
			animator.SetBool ("hit", true);
		}
	}

	void OnDestroy(){
		// Play ad?

		// Watch ad - Get second attempt
		// Show shop
		// Show retry menu
		// Init game
	}
}
