using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameMenu {
	public GameObject gameObject;
	public Vector2 position;

	public GameMenu(GameObject context){
		gameObject = context;
		position = gameObject.GetComponent<Image>().rectTransform.localPosition;
	}
}

public class GameMenuManager {
	public static List<GameObject> menus;
	public static GameObject current;
	public static bool projecting;
	private static GameObject last;

	public static void LinkMenu(GameObject menuObject){		// Menus typically linked in "PresentMenu" script
		if(menus == null) menus = new List<GameObject>();
		GameMenuManager.menus.Add (menuObject);
	}

	public static void ShowMenu(int id){
		projecting = true;
		for(int i = 0; i < menus.Count; i++){
			if (i != id) {
				menus [i].SetActive (false);
			} else {
				menus [i].SetActive (true);
				current = menus [i];
			}
		}
	}

	public static void HideAll(){
		projecting = false;
		for (int i = 0; i < menus.Count; i++) {
			menus [i].SetActive (false);
		}
	}
}