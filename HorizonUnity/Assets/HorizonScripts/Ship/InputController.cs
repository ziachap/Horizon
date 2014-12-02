using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ShipController))]
public class InputController : MonoBehaviour {

	// Public Variables
	ShipController ship;
	public CameraController cameraController;

	// Use this for initialization
	void Start () {
		ship = gameObject.GetComponent<ShipController> ();
	}

	void FixedUpdate()
	{
	}
	
	// Update is called once per frame
	void Update () {
			// Thrust input
			if (Input.GetAxis ("Thrust") > 0) {
				ship.flight.AddThrustPercentage (1);
			}
			if (Input.GetAxis ("Thrust") < 0) {
				ship.flight.AddThrustPercentage (-1);
			}
									
			// Roll input
			if (Input.GetAxis ("Roll") > 0) {
				ship.flight.Roll (-8);
			}
			if (Input.GetAxis ("Roll") < 0) {
				ship.flight.Roll (8);
			}
									
			// Yaw Input
			float mouseXPercentage = (Input.mousePosition.x - (Screen.width / 2)) / Screen.width;
			ship.flight.Yaw (mouseXPercentage * ship.flight.maxAngularVelocity);
								
			// Pitch Input
			float mouseYPercentage = (Input.mousePosition.y - (Screen.height / 2)) / Screen.height;
			ship.flight.Pitch (mouseYPercentage * ship.flight.maxAngularVelocity);

			// Weapon Aim Input
			//float zTarget = (flight.rigidbody.position + (flight.rigidbody.transform.up.normalized*1000)).z;
			Vector3 aimTarget;
			Ray ray = cameraController.activeCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 5000f) && (hit.point - ship.flight.transform.position).magnitude > 8) {
				aimTarget = hit.point;
			}
		else aimTarget = cameraController.activeCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100000));
			ship.rightWeapon.SetTarget(aimTarget);
			ship.leftWeapon.SetTarget(aimTarget);

			// Weapon Fire Input
			if(Input.GetMouseButton(0)) {
				ship.rightWeapon.EngageFire();
				ship.leftWeapon.EngageFire();
			}
			else {
				ship.rightWeapon.DisengageFire();
				ship.leftWeapon.DisengageFire();
			}
	}
}
