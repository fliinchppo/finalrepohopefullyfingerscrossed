using UnityEngine;
using System.Collections;

public class BetterPlayerMovement : MonoBehaviour {

	/*
	*
	*
	*				This component is only enabled for "my player", (i.e. the local client machine)
	*
	*
	*/

	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public float speed;
	public float jumpSpeed;
	private float verticalVelocity = 0;
	Vector3 direction = Vector3.zero;
	CharacterController cc;
	Animator anim;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		direction = transform.rotation * new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		//if (direction.magnitude > 1f) {
		//	direction = direction.normalized;
		//}

		anim.SetFloat ("Vspeed", Input.GetAxis ("Vertical"));
		anim.SetFloat ("Hspeed", Input.GetAxis ("Horizontal"));

		if (cc.isGrounded && Input.GetButtonDown("Jump")) {
			verticalVelocity = jumpSpeed;
		}
	}

	//-------Updated at a constant rate-----------------------------------------------------------------------------------------------------------------------------------------
	void FixedUpdate() {
		Vector3 dist = direction * speed * Time.deltaTime;

		if (cc.isGrounded && verticalVelocity < 0) {
			//anim.SetBool ("Jumping", false);
		} else {
			if (Mathf.Abs (verticalVelocity) > jumpSpeed * 0.75f) {					
				//anim.SetBool ("Jumping", true);
			}

			verticalVelocity += Physics.gravity.y * Time.deltaTime * 3;
		}

		dist.y = verticalVelocity * Time.deltaTime;
		cc.Move (dist);
	}
}