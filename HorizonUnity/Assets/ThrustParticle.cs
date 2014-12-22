using UnityEngine;
using System.Collections;

public class ThrustParticle : MonoBehaviour {

	public int maxRate;
	public FlightController flight;

	ParticleSystem partSys;

	// Use this for initialization
	void Start () {
		partSys = gameObject.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		partSys.emissionRate = (flight.GetThrust () / flight.maxThrust) * maxRate;
	}
}
