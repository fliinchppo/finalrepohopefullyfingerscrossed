using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class WeaponSwap : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------
	
	public string loadoutWeapon1;
	public string loadoutWeapon2;
	
	private int wSlot = 0;
	private List<WeaponContainer> weapons = new List<WeaponContainer>();

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------
	void Start () {
		TextAsset jsonList = Resources.Load ("weaponsList") as TextAsset; // Load weapons list json file
		var weaponList = JSON.Parse (jsonList.text); // Parse weapon file

		// Get chosen loadout weapons and store as WeaponContainer class
		WeaponContainer w1 = new WeaponContainer (weaponList [loadoutWeapon1]);
		WeaponContainer w2 = new WeaponContainer (weaponList [loadoutWeapon2]);

		// Add WeaponContainers to weapons list
		weapons.Add (w1);
		weapons.Add (w2);
		
		SetWeapon (0, false); // Equip weapon in wSlot 0
	}
	
	//-------Update is called once per frame-------------------------------------------------------------------------------------------------------
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
			SetWeapon(wSlot, true);
		}
		
		if (mwheelInput > 0f) {
			// scroll up, swap to weapon slot 1 in array
			wSlot = 0;
			SetWeapon(wSlot, true);
		}
		
		if (mwheelInput < 0f) {
			// scroll down, swap to weapon slot 2 in array
			wSlot = 1;
			SetWeapon(wSlot, true);
		}
	}

	void SetWeapon (int w, bool swap) { // Set the current weapon to weapons [w]
		int otherWeapon;
		PlayerShooting playerShooting = GetComponent<PlayerShooting>();
		WeaponContainer currentWeapon = playerShooting.cW;

		if (swap == true) {
			if (w == 0) {
				otherWeapon = 1;
			} else {
				otherWeapon = 0;
			}
			weapons [otherWeapon] = currentWeapon;
		}

		// Setting the variables in PlayerShooting to match the chosen weapon

		currentWeapon.currentAmmo = weapons [w].currentAmmo;
		currentWeapon.reserveAmmo = weapons [w].reserveAmmo;
		currentWeapon.clipSize = 	weapons [w].clipSize;
		currentWeapon.reserveAmmoMax = weapons [w].reserveAmmoMax;
		currentWeapon.automatic = 	weapons [w].automatic;
		currentWeapon.damage = 		weapons [w].damage;
		currentWeapon.hitscan = 	weapons [w].hitscan;
		currentWeapon.reloadTime = 	weapons [w].reloadTime;
		currentWeapon.shotInterval = weapons [w].shotInterval;

		playerShooting.UpdateHUD ();

		Debug.Log (weapons [w]);
	}

	void SaveWeaponAmmo (int w) { // Saves the amount of ammo in the weapon *DEPRECATED*
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

