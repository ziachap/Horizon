using UnityEngine;
using System.Collections;

[RequireComponent (typeof (FlightController))]
public class InputController : MonoBehaviour {

	public FlightController flightController;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate()
	{
	}
	
	// Update is called once per frame
	void Update () {

		// Roll input
		if (Input.GetAxis ("Roll") > 0) {
				flightController.Roll (-8);
		}
		if (Input.GetAxis ("Roll") < 0) {
				flightController.Roll (8);
		}

		// Yaw Input
		float mouseXPercentage = (Input.mousePosition.x - (Screen.width / 2)) / Screen.width;
		flightController.Yaw (mouseXPercentage * flightController.maxAngularVelocity);
		
		// Pitch Input
		float mouseYPercentage = (Input.mousePosition.y - (Screen.height / 2)) / Screen.height;
		flightController.Pitch (mouseYPercentage * flightController.maxAngularVelocity);
	}
}
