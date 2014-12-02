using UnityEngine;
using System.Collections;

public class CursorRightText : MonoBehaviour {

	public ShipController ship;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.guiText.text = "S // " + (int)(100*ship.GetShield()/ship.maxShield) + "%\n" + 
			"H // " + (int)(100*ship.GetHull()/ship.maxHull) + "%";
		Vector2 offset = new Vector2 (22,20);
		this.guiText.pixelOffset = new Vector2 (Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height/2) + offset;
	}
}
