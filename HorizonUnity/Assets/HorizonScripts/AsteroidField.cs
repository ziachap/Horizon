using UnityEngine;
using System.Collections;

public class AsteroidField : MonoBehaviour {

	public float density;
	public int range;
	public Rigidbody asteroid;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < (int)(density*range); i++) {
			Random.seed = i*5;
			GameObject.Instantiate (asteroid, this.transform.position + new Vector3(Random.Range (-range/2,range/2), 
			                                              Random.Range (-range/2,range/2), 
			                                              Random.Range (-range/2,range/2)),
			    Random.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
