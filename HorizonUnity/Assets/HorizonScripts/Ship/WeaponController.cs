using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class WeaponController : MonoBehaviour {

	public Transform shipTransform;
	public Vector3 relativePosition;
	public ProjectileController projectile;
	public int coolDown = 0;

	AudioSource audioSource;

	Vector3 target;
	bool firing;
	int currentCoolDown;

	// Use this for initialization
	void Start () {
		target = Vector3.zero;
		this.transform.parent = shipTransform;
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void Update () {
		// Fire if engaged
		if (firing && currentCoolDown <= 0) {
			audioSource.Play();
			GameObject.Instantiate (projectile, transform.position, transform.rotation);
			currentCoolDown = coolDown;
		}
		if(currentCoolDown > 0) currentCoolDown--;
	}

	// Update
	void LateUpdate () {
		// Update rotation
		//transform.LookAt (target);
		Vector3 newUp = Vector3.Cross (Vector3.Cross (target - transform.position, shipTransform.up),target - transform.position);
		transform.rotation = Quaternion.LookRotation (target - transform.position, newUp);

		// Update position
		//transform.localPosition = relativePosition;

	}

	public void EngageFire () {
		firing = true;
	}
	public void DisengageFire () {
		firing = false;
	}

	// Points weapon at target
	public void SetTarget (Vector3 target) {
		this.target = target;
		//
	}

	public int getCoolDown() {
		return currentCoolDown;
	}
}
