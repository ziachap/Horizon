using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (Rigidbody))]
public class ProjectileController : MonoBehaviour {

	public float projectileSpeed;
	public int range;
	public float damage;

	// Use this for initialization
	void Start () {

	}
	
	// Update
	void LateUpdate () {
		this.transform.position += this.transform.forward.normalized * projectileSpeed;

		// Destroy projectile after a while
		range--;
		if (range <= 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.collider.name == "Body"){
			ShipController ship = col.collider.gameObject.transform.parent.gameObject.GetComponent<ShipController> ();
			ship.Damage(this.damage);
		}
		Destroy (gameObject);
	}
}
