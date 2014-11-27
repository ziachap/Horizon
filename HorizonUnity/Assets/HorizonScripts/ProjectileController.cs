using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class ProjectileController : MonoBehaviour {

	public float projectileSpeed;
	public int life;

	// Use this for initialization
	void Start () {
		this.rigidbody.velocity = this.transform.forward.normalized * projectileSpeed;
	}
	
	// Update
	void FixedUpdate () {
		life--;
		if (life <= 0) {
			Destroy (gameObject);
		}
	}
}
