using UnityEngine;
using System.Collections;

public class ThirdPersonShipCamera : MonoBehaviour {

	public Transform target;
	public float cameraDistance;
	public float cameraHeight;
	Vector3 angularVelocity;
	Vector3 lookPoint;
	
	// Use this for initialization
	void Start () {
		angularVelocity = Vector3.zero;
		lookPoint = Vector3.zero;
	}
	
	void FixedUpdate () {
		// Rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, 
		                     Quaternion.LookRotation (target.up, Vector3.Cross (target.right, target.up)),
		                     0.1f);
		// Position
		Vector3 targetPos = target.position + (target.up * -cameraDistance) 
			+ (Vector3.Cross(target.transform.up, target.right) * -cameraHeight);
		this.transform.position = Vector3.Slerp(camera.transform.position, targetPos, 0.3f);
	}
}
