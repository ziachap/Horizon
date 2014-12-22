using UnityEngine;
using System.Collections;

public class BaseAI : MonoBehaviour {

	public float agility;

	ShipController ship;
	Vector3 flightTarget;
	Vector3 aimTarget;
	int aimNum;

	public enum AIState {Idle, Tailing, Evading};
	public AIState state;

	void Start () {
		ship = gameObject.GetComponent<ShipController> ();
	}

	void Update () {
		if (state != AIState.Idle) {
			// Flight control
			FlyToTarget ();
		}
		if (state == AIState.Tailing) {
			AttackTarget ();
		}
	}

	public void SetFlightTarget (Vector3 target) {
		flightTarget = target;
	}

	public void SetAimTarget (Vector3 target) {
		aimTarget = target;
	}

	void FlyToTarget () {

		// Manage steering controls
		AlignToTarget ();

		// Manage thrust controls
		float stopDistance = 8;
		float slowingDistance = 100;
		float distance = (flightTarget - ship.transform.position).magnitude;

		if (distance < stopDistance) {;
			ship.flight.SetThrustPercentage (0);
		} 
		else if (distance < slowingDistance) {
			float newThrustPercentage = (distance-stopDistance)/(slowingDistance-stopDistance);
			ship.flight.SetThrustPercentage (newThrustPercentage*100);
		} 
		else {
			ship.flight.SetThrustPercentage (100);
		}
						
	}

	void AlignToTarget () {
		Vector3 currentDirection = ship.transform.forward.normalized;
		Vector3 toTarget = (flightTarget - ship.transform.position).normalized;
		Vector3 rotation = transform.InverseTransformDirection (Vector3.RotateTowards(currentDirection, toTarget, 100, 0));

		// Determine if facing toward target or away (Dot Product)
		bool facingToward = false;
		float dot = Vector3.Dot (toTarget, currentDirection);
		if (dot > 0) facingToward = true;

		// Send out flight controls to flightController
		if (facingToward) {
			ship.flight.Yaw (-rotation.x * ship.flight.maxAngularVelocity);
			ship.flight.Pitch (rotation.z * ship.flight.maxAngularVelocity);
		}
		else {
			// YAW
			if (rotation.x >= 0) 
				ship.flight.Yaw (-agility * ship.flight.maxAngularVelocity);
			else
				ship.flight.Yaw (agility * ship.flight.maxAngularVelocity);
			
			// PITCH
			if (rotation.z >= 0) 
				ship.flight.Pitch (agility * ship.flight.maxAngularVelocity);
			else
				ship.flight.Pitch (-agility * ship.flight.maxAngularVelocity);
		}

		/// Random rolling
		float random = Random.value-0.5f;
		if (random > 0.2f || random < -0.2f) ship.flight.Roll (random * ship.flight.maxAngularVelocity);
	}

	void AttackTarget() {
		// Only bother attacking if facing the target
		Vector3 currentDirection = ship.transform.forward.normalized;
		Vector3 toTarget = (aimTarget - ship.transform.position).normalized;
		bool facingToward = false;
		float dot = Vector3.Dot (toTarget, currentDirection);
		if (dot > 0) facingToward = true;

		if (facingToward) {
			// Establish aim point. Introduce an offset to the aim to simulate human error
			float aimOffset = Mathf.Sin(aimNum);
			Vector3 aimOffsetVector = Vector3.Cross (ship.transform.up, toTarget).normalized * aimOffset * 1f;
			aimNum++;

			Vector3 aimPoint = aimTarget + aimOffsetVector;

			// Aim weapons at aim point
			ship.AimAllWeapons (aimPoint);

			// Engage weapons
			ship.EngageAllWeapons ();
		} 
		else {
			// If not facing target, disengage weapons
			ship.DisengageAllWeapons ();
		}
	}
}
