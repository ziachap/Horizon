using UnityEngine;
using System.Collections;

public class GUITextAligner : MonoBehaviour {

	public enum AlignmentX {Left, Right}
	public enum AlignmentY {Top, Bottom}
	public bool AlignX;
	public bool AlignY;
	public AlignmentX alignmentX;
	public AlignmentY alignmentY;
	public Vector2 offset;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (AlignX) {
			if (alignmentX == AlignmentX.Left)
				guiText.pixelOffset = new Vector2 (offset.x - (Screen.width / 2), guiText.pixelOffset.y);
			else
				guiText.pixelOffset = new Vector2 ((Screen.width / 2) - offset.x, guiText.pixelOffset.y);
		}
		if (AlignY) {
			if (alignmentY == AlignmentY.Top)
				guiText.pixelOffset = new Vector2 (guiText.pixelOffset.x, (Screen.height / 2) - offset.y);
			else
				guiText.pixelOffset = new Vector2 (guiText.pixelOffset.x, offset.y - (Screen.height / 2));
		}
	}
}
