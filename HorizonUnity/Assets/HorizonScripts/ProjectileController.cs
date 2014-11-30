using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class ProjectileController : MonoBehaviour {

	public float projectileSpeed;
	public int range;

	// Use this for initialization
	void Start () {
		this.rigidbody.velocity = this.transform.forward.normalized * projectileSpeed;
	}
	
	// Update
	void FixedUpdate () {

		// Destroy projectile after a while
		range--;
		if (range <= 0) {
			Destroy (gameObject);
		}
	}
}
