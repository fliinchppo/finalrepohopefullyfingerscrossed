using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class WeaponSwap : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	
	public string loadoutWeapon1;
	public string loadoutWeapon2;
	
	private int wSlot = 0;
	private List<JSONNode> weapons = new List<JSONNode>();

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		TextAsset jsonList = Resources.Load ("weaponsList") as TextAsset; // Load weapons list json file
		var weaponList = JSON.Parse (jsonList.text); // Parse weapon file
		weapons.Add (weaponList [loadoutWeapon1]); // Get chosen loadout weapons
		weapons.Add (weaponList [loadoutWeapon2]);
		for (int i = weapons.Count - 1; i >= 0; i--) { // Set current ammo values
			weapons [i] ["currentAmmo"].AsInt = weapons [i] ["ammoClip"].AsInt;
			weapons [i] ["reserveAmmo"].AsInt = weapons [i] ["ammoReserveMax"].AsInt;
		}
		SetWeapon (0); // Equip weapon in wSlot 0
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		Swap ();
	}

	void Swap () {		
		var mwheelInput = Input.GetAxis("Mouse ScrollWheel");
		if (Input.GetButton ("SwapWeapon")) {
			if (wSlot == 0) {
				// swap to weapon slot 2 in array
				wSlot = 1;
			} else if (wSlot == 1) {
				// swap to weapon slot 1 in array
				wSlot = 0;
			}
			SetWeapon(wSlot);
		}
		
		if (mwheelInput > 0f) {
			// scroll up, swap to weapon slot 1 in array
			wSlot = 0;
			SetWeapon(wSlot);
		}
		
		if (mwheelInput < 0f) {
			// scroll down, swap to weapon slot 2 in array
			wSlot = 1;
			SetWeapon(wSlot);
		}
	}

	void SetWeapon (int w) { // Set the current weapon to weapons [w]
		PlayerShooting weapon = GetComponent<PlayerShooting>();

		SaveWeaponAmmo (w);

		// Setting the variables in PlayerShooting to match the chosen weapon

		weapon.currentAmmo = weapons [w] ["currentAmmo"].AsInt;
		weapon.reserveAmmo = weapons [w] ["reserveAmmo"].AsInt;
		weapon.clipSize = weapons [w] ["ammoClip"].AsInt;
		weapon.reserveAmmo = weapons [w] ["ammoReserveMax"].AsInt;
		weapon.automatic = weapons [w] ["automatic"].AsBool;
		weapon.damage = weapons [w] ["damage"].AsInt;
		weapon.hitscan = weapons [w] ["hitscan"].AsBool;
		weapon.reloadTime = weapons [w] ["reloadTime"].AsFloat;
		weapon.shotInterval = weapons [w] ["shotInterval"].AsFloat;

		weapon.UpdateHUD ();

		Debug.Log (weapons [w]);
	}

	void SaveWeaponAmmo (int w) { // Saves the amount of ammo in the weapon
		PlayerShooting weapon = GetComponent<PlayerShooting>();
		if (w == 0) {
			w = 1;
		} else {
			w = 0;
		}
		weapons [w] ["currentAmmo"].AsInt = weapon.currentAmmo;
		weapons [w] ["reserveAmmo"].AsInt = weapon.reserveAmmo;
		Debug.Log ("Current " + weapon.currentAmmo.ToString());
	}
}
