using UnityEngine;
using System.Collections;

public class HealthHUD : MonoBehaviour {

	public Vector2 offset;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.guiTexture.pixelInset = new Rect(offset.x-(Screen.width/2),(Screen.height/2) - (offset.y + guiTexture.pixelInset.height), guiTexture.pixelInset.width,guiTexture.pixelInset.height);
	}
}
