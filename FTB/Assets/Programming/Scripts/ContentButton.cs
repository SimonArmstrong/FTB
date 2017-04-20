using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentButton : MonoBehaviour {
	public string name;
	public int cost;
	public Sprite icon;

	public Text ui_name;
	public Text ui_price;
	public Image ui_icon;

	public bool isUnlocked = true;

	Button button;

	// Use this for initialization
	void Start () {
		ui_icon.sprite = icon;
		button = GetComponent<Button> ();
		//button.interactable = isUnlocked;

		if (!isUnlocked) {
			ui_name.text = "???????????";
			ui_price.text = "????";
		} else {
			ui_name.text = name;
			ui_price.text = cost.ToString ();	
		}
	}

	void Update(){
		if (!isUnlocked) {
			button.GetComponent<Image> ().color = Color.black;
		} else if (cost > Flo.currency.max) {
			button.GetComponent<Image> ().color = Color.red;
		} else {
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	// Update is called once per frame
	public void OnClick(){
		UnlockSkin ();
	}

	public void UnlockSkin(){
		
	}
}
