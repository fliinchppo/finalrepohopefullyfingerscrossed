using UnityEngine;
using System.Collections;

public class temp3rdperson : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Camera debug_PlayerCamera;
	public Camera debug_3rdPersonCamera;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		debug_PlayerCamera.enabled = true;
		debug_3rdPersonCamera.enabled = false;
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		if (Input.GetKeyDown (KeyCode.KeypadPlus)) {
			debug_PlayerCamera.enabled = !debug_PlayerCamera.enabled;
			debug_3rdPersonCamera.enabled = !debug_3rdPersonCamera.enabled;
		}
	}
}
