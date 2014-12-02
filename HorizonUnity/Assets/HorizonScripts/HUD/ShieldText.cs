using UnityEngine;
using System.Collections;

public class ShieldText : MonoBehaviour {

	public ShipController ship;
	public Vector2 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = "HUNTER\n" + "S  " + (int)(100*ship.GetShield ()/ship.maxShield) + "%  " + "H " + (int)(100*ship.GetHull ()/ship.maxHull) + "%";
		this.guiText.pixelOffset = new Vector2(offset.x - (Screen.width/2), (Screen.height/2) - offset.y);
	}
}
