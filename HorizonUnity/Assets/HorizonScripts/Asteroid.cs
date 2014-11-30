using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Asteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Random.seed = System.DateTime.Now.Millisecond + new System.Random().Next() + (int)(1000*Time.time);
		float size = Random.Range (20,90);
		this.transform.localScale = new Vector3(size, size, size);
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody.AddRelativeTorque (new Vector3(Random.value,Random.value,Random.value)*0.1f);
	}
}
