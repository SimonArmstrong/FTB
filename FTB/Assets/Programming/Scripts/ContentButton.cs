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


	// Use this for initialization
	void Start () {
		ui_name.text = name;
		ui_price.text = cost.ToString ();
		ui_icon.sprite = icon;
	}
	
	// Update is called once per frame
	public void OnClick(){
		
	}
}
