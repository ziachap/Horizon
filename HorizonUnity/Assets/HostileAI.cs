using UnityEngine;
using System.Collections;

public class HostileAI : MonoBehaviour {

	public Transform target;
	public int tailDistance;

	BaseAI baseAI;

	// Use this for initialization
	void Start () {
		baseAI = gameObject.GetComponent<BaseAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		// AI uses a state machine

		if (baseAI.state == BaseAI.AIState.Tailing) {
			TailTarget ();
		}
	}

	void TailTarget () {
		Vector3 behindPlayer = target.position - (target.forward.normalized * tailDistance);
		baseAI.SetFlightTarget (behindPlayer);
		baseAI.SetAimTarget (target.position);
	}

	void EvadeTarget () {
	}
}
