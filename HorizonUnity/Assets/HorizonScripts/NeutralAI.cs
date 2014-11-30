using UnityEngine;
using System.Collections;

[RequireComponent (typeof (FlightController))]
public class NeutralAI : MonoBehaviour {

	FlightController flight;

	// Use this for initialization
	void Start () {
		flight = gameObject.GetComponent<FlightController> ();
	}
	
	// Update is called once per frame
	void Update () {
		flight.Yaw (0.005f);
		flight.SetThrustPercentage (51);
		flight.Pitch (0.002f);
		//flight.Roll (-0.02f);
	}
}
