using UnityEngine;
using System.Collections;

public class HUDShake : MonoBehaviour {

	public float amount;
	public float speed;
	public FlightController ship;

	Vector3 startPosition;

	int x;

	// Use this for initialization
	void Start () {
		x = 0;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		float percentage = 1;
		if (ship != null) percentage = ship.GetThrust () / ship.maxThrust;

		float newAmount = percentage * amount;
		float newSpeed = percentage * speed;

		this.transform.position = new Vector3 (startPosition.x + (newAmount * Mathf.Sin (newSpeed * x)), startPosition.y + (newAmount * Mathf.Cos ((newSpeed + 0.5f)*x)), startPosition.z);
		x++;
	}
}
