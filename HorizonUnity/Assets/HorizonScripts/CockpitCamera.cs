using UnityEngine;
using System.Collections;

public class CockpitCamera : MonoBehaviour {

	public Transform target;
	public float drag;
	public float cameraDistance;
	public float cameraHeight;
	
	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate () {
		// Rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, 
		                                      Quaternion.LookRotation (target.up, Vector3.Cross (target.right, target.up)),
		                                      drag);
		// Position
		Vector3 targetPos = target.position + (target.up * cameraDistance) 
			+ (Vector3.Cross(target.transform.up, target.right) * -cameraHeight);
		this.transform.position = Vector3.Slerp(camera.transform.position, targetPos, 1f);
	}

	void LateUpdate () {
		// Position
		Vector3 targetPos = target.position + (target.up * cameraDistance) 
			+ (Vector3.Cross(target.transform.up, target.right) * -cameraHeight);
		this.transform.position = Vector3.Slerp(camera.transform.position, targetPos, 1f);
	}
}
