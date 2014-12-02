using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public FlightController flight;
	public WeaponController leftWeapon;
	public WeaponController rightWeapon;
	public float maxShield;
	public float maxHull;
	public int shieldRegenCooldown;
	public float shieldRegenRate;
	public ParticleEmitter deathParticle;

	int currentShieldRegenCooldown;

	float oldShield;
	float _shield; float shield {
		get { 
			return _shield; 
		}
		set { 
			_shield = value;
			if (_shield > maxShield) _shield = maxShield;
			if (_shield < 0) _shield = 0;
		}
	}
	float _hull; float hull {
		get { 
			return _hull; 
		}
		set { 
			_hull = value;
			if (_hull > maxHull) _hull = maxHull;
			if (_hull < 0) _hull = 0;
		}
	}

	// Use this for initialization
	void Start () {
		shield = maxShield;
		hull = maxHull;
	}

	void FixedUpdate () {
		ManageShield ();
		ManageHull ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E))
						Damage (3);
	}

	void ManageShield () {
		// Start off cooldown timer
		if (shield < oldShield) 
		{
			currentShieldRegenCooldown = shieldRegenCooldown;
		}

		// Regenerate shield after cooldown
		if (currentShieldRegenCooldown <= 0) 
		{
			shield += shieldRegenRate;
		}

		// Update currentShieldRegenCooldown and oldShield
		currentShieldRegenCooldown--;
		oldShield = shield;
	}

	void ManageHull () {
		// Death if hull is zero
		if (hull <= 0) Destruct ();
	}

	public void Damage (float value) {
		float carryOver = shield - value;
		shield -= value;

		if (carryOver < 0) 
		{
			hull += carryOver;
		}
	}

	public float GetShield () {
		return shield;
	}

	public float GetHull () {
		return hull;
	}

	public void SetShield (float value) {
		shield = value;
	}
	
	public void SetHull (float value) {
		hull = value;
	}

	void Destruct(){
		GameObject.Instantiate (deathParticle, transform.position, transform.rotation);
		Destroy (gameObject);
	}

}
