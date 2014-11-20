using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class MoveController : MonoBehaviour {

	// Public Variables
	public float maxThrust;
	public float maxAngularVelocity;
	public bool inertia;

	// Physics Variables
	Vector3 velocity;
	Vector3 acceleration;
	Vector3 angularVelocity;
	Vector3 angularAcceleration;
	float _thrust; float thrust {
		get { 
			return _thrust; 
		}
		set { 
			_thrust = value;
			if (_thrust > maxThrust) _thrust = maxThrust;
			if (_thrust < 0) _thrust = 0;
		}
	}

	void Start()
	{
		rigidbody.maxAngularVelocity = maxAngularVelocity;
		angularVelocity = Vector3.zero;
	}

	void FixedUpdate()
	{	
		// Apply Rotation
		rigidbody.transform.Rotate (new Vector3 (angularVelocity.x, angularVelocity.z, angularVelocity.y));

		// Apply Thrust
		rigidbody.AddRelativeForce (Vector3.up * thrust);
	}

	void Update()
	{

		// Main Thruster Input
		if (Input.GetKey (KeyCode.W)) 
			thrust += 2f;
		if (Input.GetKey (KeyCode.S)) 
			thrust -= 2f;

		// Ship Roll Input
		if (Input.GetKey (KeyCode.A)) 
			angularVelocity.z = 2f;
		if (Input.GetKey (KeyCode.D)) 
			angularVelocity.z = -2f;

		angularVelocity.z = Vector3.Lerp (angularVelocity, Vector3.zero, 0.1f).z;

		// Ship Pitch/Yaw Input
		angularVelocity.x = (Input.mousePosition.y - (Screen.height / 2)) * 0.0045f;
		angularVelocity.y = (Input.mousePosition.x - (Screen.width / 2)) * 0.0035f;

		// Inertia
		//if (inertia) rigidbody.velocity = Vector3.Lerp (rigidbody.velocity, Vector3.zero, 0.5f);
	}
}
