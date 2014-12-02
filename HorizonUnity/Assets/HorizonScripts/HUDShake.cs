using UnityEngine;
using System.Collections;

public class HUDShake : MonoBehaviour {

	public float amount;
	public float speed;
	public FlightController ship;

	int x;

	// Use this for initialization
	void Start () {
		x = 0;
	}
	
	// Update is called once per frame
	void Update () {

		float percentage = 1;
		if (ship != null) percentage = ship.GetThrust () / ship.maxThrust;

		float newAmount = percentage * amount;
		float newSpeed = percentage * speed;

		this.transform.position = new Vector3 (9.442081f + (newAmount * Mathf.Sin (newSpeed * x)), 6.837051f + (newAmount * Mathf.Cos ((newSpeed + 0.5f)*x)), -10.89323f);
		x++;
	}
}
