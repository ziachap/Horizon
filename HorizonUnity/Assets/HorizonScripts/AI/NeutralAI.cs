using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ShipController))]
public class NeutralAI : MonoBehaviour {

	ShipController ship;

	// Use this for initialization
	void Start () {
		ship = gameObject.GetComponent<ShipController> ();
	}
	
	// Update is called once per frame
	void Update () {
		ship.flight.Yaw (0.009f);
		ship.flight.SetThrustPercentage (20);
		ship.flight.Pitch (0.002f);
		//flight.Roll (-0.02f);
	}
}
