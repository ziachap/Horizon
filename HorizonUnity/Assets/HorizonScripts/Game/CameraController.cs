using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	int _currentCamera; int currentCamera {
		get { 
			return _currentCamera; 
		}
		set { 
			if (value > Camera.allCamerasCount-1) _currentCamera = 0;
			else _currentCamera = value;
		}
	}

	public ThirdPersonShipCamera thirdPersonCamera;
	public CockpitCamera firstPersonCamera;
	public Camera activeCamera;

	// Use this for initialization
	void Start () {
		//Camera.SetupCurrent (thirdPersonCamera.camera);
		SwitchToFirstPerson ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Tab)) 
		{
			if(thirdPersonCamera.GetComponent<Camera>().enabled) SwitchToFirstPerson();
			else SwitchToThirdPerson();
			//NextCamera();
		}
	}

	void SwitchToFirstPerson(){
		activeCamera = firstPersonCamera.gameObject.GetComponent<Camera>();
		thirdPersonCamera.gameObject.GetComponent<Camera>().enabled = false;
		thirdPersonCamera.gameObject.GetComponent<AudioListener>().enabled = false;
		firstPersonCamera.gameObject.GetComponent<Camera>().enabled = true; 
		firstPersonCamera.gameObject.GetComponent<AudioListener>().enabled = true;
	}

	void SwitchToThirdPerson(){
		activeCamera = thirdPersonCamera.gameObject.GetComponent<Camera>();
		thirdPersonCamera.gameObject.GetComponent<Camera>().enabled = true;
		thirdPersonCamera.gameObject.GetComponent<AudioListener>().enabled = true;
		firstPersonCamera.gameObject.GetComponent<Camera>().enabled = false; 
		firstPersonCamera.gameObject.GetComponent<AudioListener>().enabled = false;
	}

	void NextCamera(){
		Camera.allCameras[currentCamera].tag = "";

		currentCamera++;
		//Camera.allCameras[currentCamera].enabled = true;
		Camera.allCameras[currentCamera].tag = "MainCamera";
		Camera.SetupCurrent (Camera.allCameras [currentCamera]);
	}
}
