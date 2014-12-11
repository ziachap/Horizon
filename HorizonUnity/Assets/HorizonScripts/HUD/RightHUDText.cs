using UnityEngine;
using System.Collections;

public class RightHUDText : MonoBehaviour {

	public ShipController ship;
	public Vector2 offset;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = "L // LASER\n"+"R // LASER";
		this.guiText.pixelOffset = new Vector2((Screen.width/2) - offset.x, (Screen.height/2) - offset.y);
	}
}
