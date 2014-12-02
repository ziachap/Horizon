using UnityEngine;
using System.Collections;

public class CursorLeftText : MonoBehaviour {

	public WeaponController leftWeapon;
	public WeaponController rightWeapon;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int leftPercentage = 10 - (int)(10 * leftWeapon.getCoolDown () / leftWeapon.coolDown);
		int rightPercentage = 10 - (int)(10 * rightWeapon.getCoolDown () / rightWeapon.coolDown);

		if (leftPercentage == 10) this.guiText.text = "L";
		else this.guiText.text = "" + leftPercentage;

		this.guiText.text = this.guiText.text + " // ";

		if (rightPercentage == 10) this.guiText.text = this.guiText.text + "R";
		else this.guiText.text = this.guiText.text + rightPercentage;

		Vector2 offset = new Vector2 (-22,18);
		this.guiText.pixelOffset = new Vector2 (Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height/2) + offset;
	}
}
