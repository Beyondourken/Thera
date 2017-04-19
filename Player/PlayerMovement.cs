using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float walkMoveStopRadius = 0.2f;
	[SerializeField] float attackMoveStopRadius = 1f;
    ThirdPersonCharacter thirdPersonCharacter;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
	//Vector3 currentDestination, clickPoint;
	//bool isInDirectMode = false;  //TODO consider making static    
	private bool jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
		thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
       // currentDestination = transform.position;
    }

	private void Update()
	{
		if (!jump)
		{
			jump = Input.GetButtonDown("Jump");
		}
	}

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
		//if (Input.GetKeyDown (KeyCode.G)) {   // G = gamepad TODO add menu option to select controller
		//	isInDirectMode = !isInDirectMode; //toggle control mode
		//	currentDestination = transform.position; // clear click target
		//}
		//if (isInDirectMode) {
			ProcessDirectMovement();
	//	} else {
	//		ProcessMouseMovement ();
	//	}
    }

	private void ProcessDirectMovement() {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool crouch = Input.GetKey(KeyCode.C);

		// calculate camera relative direction to move:
		Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
		Vector3 cameraMove = v*cameraForward + h*Camera.main.transform.right;
		thirdPersonCharacter.Move(cameraMove, crouch, jump);
		jump = false;
	}

//	private void ProcessMouseMovement ()
//	{
//		if (Input.GetMouseButton (0)) {
//			clickPoint = cameraRaycaster.hit.point;
//			switch (cameraRaycaster.layerHit) {
//			case Layer.Walkable:
	//			currentDestination = (ShortDestination(clickPoint, walkMoveStopRadius));


	//			break;
	//		case Layer.Enemy:
	//			currentDestination = (ShortDestination(clickPoint, attackMoveStopRadius));
	//			break;
	//		default:
	//			print ("untagged target");
	//			return;
	//		}
	//	}
//		WalkToDestination ();
//	}

//	void WalkToDestination ()
//	{
//		var playerToClickPoint = currentDestination - transform.position;
//		if (playerToClickPoint.magnitude > 0) {
	//		thirdPersonCharacter.Move (playerToClickPoint, false, false);
//		}
//		else {
	//		thirdPersonCharacter.Move (Vector3.zero, false, false);
//		}
	//}

//	Vector3 ShortDestination(Vector3 destination, float shortening) {
//		Vector3 reductionVector = (destination - transform.position).normalized * shortening;
//		return destination - reductionVector;
//	}


//	void OnDrawGizmos() {
//		Gizmos.color = Color.black;
//		Gizmos.DrawLine (transform.position, currentDestination);
//		Gizmos.DrawSphere (currentDestination, 0.1f);
//		Gizmos.DrawSphere (clickPoint, 0.15f);
//	}
}

