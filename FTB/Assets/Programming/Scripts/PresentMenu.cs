using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentMenu : MonoBehaviour {
	public Image shop_menu;
	public Image main_menu;
	public Image retry_menu;
	public Vector2 start;

	public RectTransform rt;
	public bool transition = false;

	public enum Menu {
		Shop,
		Retry,
		Main
	}

	public Menu currentMenu;

	private void Start(){
		GameMenuManager.LinkMenu (shop_menu.gameObject);
		GameMenuManager.LinkMenu (retry_menu.gameObject);
	}

	public void Shop () { currentMenu = Menu.Shop;  rt = shop_menu.GetComponent<RectTransform>  (); start = rt.localPosition; GameMenuManager.ShowMenu (0); transition = true; }
	public void Retry() { currentMenu = Menu.Retry;	rt = retry_menu.GetComponent<RectTransform> (); start = rt.localPosition; GameMenuManager.ShowMenu (1);  transition = true; }
	public void MMain() { currentMenu = Menu.Main;  rt = main_menu.GetComponent<RectTransform>  (); start = rt.localPosition; ShowDeathMenu.show = false; transition = true; }
	
	public void Update(){
		if (Flo.isDead && !GameMenuManager.projecting) {
			GameMenuManager.ShowMenu (1);
		}
		if (transition) {
			switch (currentMenu) {
			case Menu.Shop:
				break;
			case Menu.Main:
				//rt.localPosition = rt.localPosition + new Vector3 (0, 2000, 0) * Time.deltaTime;
				break;
			case Menu.Retry:
				//rt.localPosition = rt.localPosition + new Vector3 (0, 2000, 0) * Time.deltaTime;
				break;
			default:
				//rt.localPosition = new Vector3 (0, -1200, 0);
				break;
			}
		}

		if (rt != null && Map.isInGame) {
			//CloseCurrentMenu ();
		}
	}

	public void CloseCurrentMenu(){
		rt.localPosition = new Vector3 (0, -1200, 0);
	}
}
