using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin {
	public string name;
	public List<Sprite> frames;
	public Skin () {
		if(frames == null) frames = new List<Sprite> ();
	}
	public Skin (List<Sprite> sprites) {
		if(frames == null) frames = new List<Sprite> ();
		frames.AddRange (sprites);
	}
}

public static class Skins {
	public static List<Skin> skins;
	public static void Init(){
		skins = new List<Skin> ();
	}
}
