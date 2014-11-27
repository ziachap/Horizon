using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class FlightController : MonoBehaviour {

	// Public Variables
	public float maxThrust;
	public float maxAngularVelocity;

	// Private Variables
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
	
	// Use this for initialization
	void Start () {
		thrust = 0;
		rigidbody.maxAngularVelocity = maxAngularVelocity;
	}

	// Physics update
	void FixedUpdate () {

		// Apply thrust
		this.rigidbody.AddRelativeForce (new Vector3(0,thrust,0));

	}

	// Update is called once per frame
	void Update () {
		//SetThrustPercentage (100);
	}

	// Increase Thrust

	// Set thrust to a percentage of ship's maximum thrust
	public void SetThrustPercentage (float percentage)
	{
		if (percentage == 0) 
			thrust = 0;
		else 
			thrust = maxThrust * (percentage / 100);
	}

	public void AddThrustPercentage (float percentage)
	{
		float newPercentage = (thrust / maxThrust) + (percentage / 100);
		thrust = maxThrust * newPercentage;
	}

	// Add a specific value to the thrust
	public void AddThrust (float amount)
	{
		thrust += amount;
	}

	// Set thrust to to a specific value
	public void SetThrust (float amount)
	{
		thrust = amount;
	}

	// Pitch rotation
	public void Pitch (float amount) {
		this.rigidbody.AddRelativeTorque (new Vector3 (amount,0,0));
	}

	// Yaw rotation
	public void Yaw (float amount) {
		this.rigidbody.AddRelativeTorque (new Vector3 (0,0,amount));
	}

	// Roll	rotation
	public void Roll (float amount) {
		this.rigidbody.AddRelativeTorque (new Vector3 (0,amount,0));
	}
}
