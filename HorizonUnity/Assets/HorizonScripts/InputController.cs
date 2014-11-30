using UnityEngine;
using System.Collections;

[RequireComponent (typeof (FlightController))]
public class InputController : MonoBehaviour {

	// Public Variables
	FlightController flight;
	public WeaponController leftWeapon;
	public WeaponController rightWeapon;

	// Use this for initialization
	void Start () {
		flight = gameObject.GetComponent<FlightController> ();
	}

	void FixedUpdate()
	{
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			// Thrust input
			if (Input.GetAxis ("Thrust") > 0) {
				flight.AddThrustPercentage (1);
			}
			if (Input.GetAxis ("Thrust") < 0) {
				flight.AddThrustPercentage (-1);
			}
									
			// Roll input
			if (Input.GetAxis ("Roll") > 0) {
				flight.Roll (-8);
			}
			if (Input.GetAxis ("Roll") < 0) {
				flight.Roll (8);
			}
									
			// Yaw Input
			float mouseXPercentage = (Input.mousePosition.x - (Screen.width / 2)) / Screen.width;
			flight.Yaw (mouseXPercentage * flight.maxAngularVelocity);
								
			// Pitch Input
			float mouseYPercentage = (Input.mousePosition.y - (Screen.height / 2)) / Screen.height;
			flight.Pitch (mouseYPercentage * flight.maxAngularVelocity);

			// Weapon Aim Input
			//float zTarget = (flight.rigidbody.position + (flight.rigidbody.transform.up.normalized*1000)).z;
			Vector3 aimTarget;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 5000f) && (hit.point - flight.transform.position).magnitude > 20) {
				aimTarget = hit.point;
			}
			else aimTarget = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100000));
			rightWeapon.SetTarget(aimTarget);
			leftWeapon.SetTarget(aimTarget);

			// Weapon Fire Input
			if(Input.GetMouseButton(0)) {
				rightWeapon.EngageFire();
				leftWeapon.EngageFire();
			}
			else {
				rightWeapon.DisengageFire();
				leftWeapon.DisengageFire();
			}
		}
	}
}
