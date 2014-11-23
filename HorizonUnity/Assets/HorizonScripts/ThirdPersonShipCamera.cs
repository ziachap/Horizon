using UnityEngine;
using System.Collections;

public class ThirdPersonShipCamera : MonoBehaviour {

	public Transform target;
	public float cameraDistance;
	public float cameraHeight;
	
	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate () {
		// Rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, 
		                     Quaternion.LookRotation (target.up, Vector3.Cross (target.right, target.up)),
		                     0.3f);
		// Position
		Vector3 targetPos = target.position + (target.up * -cameraDistance) 
			+ (Vector3.Cross(target.transform.up, target.right) * -cameraHeight);
		this.transform.position = Vector3.Slerp(camera.transform.position, targetPos, 1f);
	}
}
