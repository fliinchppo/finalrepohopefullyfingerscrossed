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
		direction = transform.rotation * new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")).normalized;

		if (direction.magnitude > 1f) {
			direction = direction.normalized;
		}

		anim.SetFloat ("Vspeed", Input.GetAxis ("Vertical"));
		anim.SetFloat ("Hspeed", Input.GetAxis ("Horizontal"));
	}

	//-------Updated at a constant rate-----------------------------------------------------------------------------------------------------------------------------------------
	void FixedUpdate() {
		cc.SimpleMove (direction * speed);
	}
}
