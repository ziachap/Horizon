using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody.AddRelativeTorque (new Vector3(0,3000,0));
	}
}
