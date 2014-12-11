using UnityEngine;
using System.Collections;

public class RightHUDPanel : MonoBehaviour {

	public Vector2 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.guiTexture.pixelInset = new Rect((Screen.width/2) - offset.x - guiTexture.pixelInset.width,(Screen.height/2) - offset.y - guiTexture.pixelInset.height, guiTexture.pixelInset.width,guiTexture.pixelInset.height);
	}
}
