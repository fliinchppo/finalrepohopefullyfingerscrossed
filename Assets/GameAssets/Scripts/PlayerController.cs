using UnityEngine;
using System.Collections;

public class PlayerController : Photon.MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public float jumpSpeed = 8f;
	public float gravity = 20f;
	public float normalSpeed = 12f;
	public float sprintSpeed = 20f;
	private float movementSpeed;
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
			movementDirection *= movementSpeed;	

			//-------Jumping----------------------------------------------------------------------------------------------------------------------------------------------------
			if (Input.GetButtonDown ("Jump") && hasJumped == false) {
				movementDirection.y = movementSpeed;
				hasJumped = true;
			}

			if (Input.GetButtonUp ("Jump")) {
				hasJumped = false;
			}

			//-------Sprinting--------------------------------------------------------------------------------------------------------------------------------------------------
			if (Input.GetButton ("Sprint")) {
				movementSpeed = sprintSpeed;
				isSprinting = true;
			} else {
				movementSpeed = normalSpeed;
				isSprinting = false;
			}
		}

		//-------Apply gravity--------------------------------------------------------------------------------------------------------------------------------------------------
		movementDirection.y -= gravity * Time.deltaTime;
		controller.Move (movementDirection * Time.deltaTime);
	}
}