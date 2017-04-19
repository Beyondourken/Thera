using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	[SerializeField] Camera firstPersonCamera;
	[SerializeField] Camera thirdPersonCamera;
	private bool switchFPCamera = false;

	// Use this for initialization
	void Start () {
		thirdPersonCamera.GetComponent<Camera>().enabled = true;
		firstPersonCamera.GetComponent<Camera>().enabled = false;
		firstPersonCamera.GetComponent<FirstPersonCameraController> ().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("1")) {
			switchFPCamera = !switchFPCamera;
			if (switchFPCamera == true) {
				firstPersonCamera.GetComponent<Camera> ().enabled = true;
				firstPersonCamera.GetComponent<FirstPersonCameraController> ().enabled = true;
				thirdPersonCamera.GetComponent<Camera> ().enabled = false;
			} else {
				thirdPersonCamera.GetComponent<Camera> ().enabled = true;
				firstPersonCamera.GetComponent<Camera> ().enabled = false;
				firstPersonCamera.GetComponent<FirstPersonCameraController> ().enabled = false;
			}
		}
	}
}
