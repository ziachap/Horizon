using UnityEngine;
using System.Collections;

public class ReticleRightText : MonoBehaviour {

	public ShipController ship;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = "V // " + (int)ship.flight.GetThrust() + " // " + (int)ship.flight.maxThrust;
	}
}
