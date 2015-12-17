using UnityEngine;
using System.Collections;

public class WeaponSwap : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public int wSlot;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {

	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		Swap ();
	}

	void Swap() {		
		var mwheelInput = Input.GetAxis("Mouse ScrollWheel");
		if (Input.GetButton ("SwapWeapon")) {
			if (wSlot == 1) {
				// swap to weapon slot 2 in array
			} else if (wSlot == 2) {
				// swap to weapon slot 1 in array
			}
		}
		
		if (mwheelInput > 0f) {
			// scroll up, swap to weapon slot 1 in array
		}
		
		if (mwheelInput < 0f) {
			// scroll down, swap to weapon slot 2 in array
		}
	}
}
