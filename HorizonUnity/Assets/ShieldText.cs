﻿using UnityEngine;
using System.Collections;

public class ShieldText : MonoBehaviour {

	public ShipController ship;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = "SHIELD // " + ship.shield + "%\n" + "HULL // " + ship.hull + "%";
	}
}
