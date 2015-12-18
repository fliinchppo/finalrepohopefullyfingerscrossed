using UnityEngine;
using System.Collections;
using SimpleJSON;

public class WeaponSwap : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	
	public string loadoutWeapon1;
	public string loadoutWeapon2;
	public JSONNode weapon1;
	public JSONNode weapon2;
	public int wSlot;

	JSONArray weaponList;
	TextAsset jsonList;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		jsonList = Resources.Load ("weaponsList") as TextAsset;
		var weaponList = JSON.Parse (jsonList.text);
		weapon1 = weaponList [loadoutWeapon1];
		weapon2 = weaponList [loadoutWeapon2];
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
				wSlot = 2;
			} else if (wSlot == 2) {
				// swap to weapon slot 1 in array
				wSlot = 1;
			}
			SetWeapon(wSlot);
		}
		
		if (mwheelInput > 0f) {
			// scroll up, swap to weapon slot 1 in array
			wSlot = 1;
			SetWeapon(wSlot);
		}
		
		if (mwheelInput < 0f) {
			// scroll down, swap to weapon slot 2 in array
			wSlot = 2;
			SetWeapon(wSlot);
		}
	}

	void SetWeapon(int w) {
		//var  = GetComponent<AudioSource>();
	}
}
