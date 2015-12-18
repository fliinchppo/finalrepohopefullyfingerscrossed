using UnityEngine;
using System.Collections;

public class PlayerController : Photon.MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public float pSpeed = 12f;
	public float pJSpeed = 8f;
	public float gravity = 20f;
	public float sprintModifier = 2f;

	private bool isSprinting;
	private bool hasJumped;
	private Vector3 movementDirection = Vector3.zero;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		isSprinting = false;
	}

	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void FixedUpdate () {
			movement ();
	}

	void movement() {
		CharacterController controller = GetComponent<CharacterController> ();

		//-------Check if player is on ground-----------------------------------------------------------------------------------------------------------------------------------
		if (controller.isGrounded) {

			//-------Handle input-----------------------------------------------------------------------------------------------------------------------------------------------
			movementDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			movementDirection = transform.TransformDirection (-movementDirection);	

			//-------Move in input direction at defined speed-------------------------------------------------------------------------------------------------------------------
			movementDirection *= pSpeed;	

			//-------Jumping----------------------------------------------------------------------------------------------------------------------------------------------------
			if (Input.GetButtonDown ("Jump") && hasJumped == false) {
				movementDirection.y = pJSpeed;
				hasJumped = true;
			}

			if (Input.GetButtonUp ("Jump")) {
				hasJumped = false;
			}

			//-------Sprinting--------------------------------------------------------------------------------------------------------------------------------------------------
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				pSpeed *= sprintModifier;
				isSprinting = true;
			}	

			if (Input.GetKeyUp (KeyCode.LeftShift)) {
				pSpeed = pSpeed / sprintModifier;
				isSprinting = false;
			}
		}

		//-------Apply gravity--------------------------------------------------------------------------------------------------------------------------------------------------
		movementDirection.y -= gravity * Time.deltaTime;
		controller.Move (movementDirection * Time.deltaTime);
	}
}