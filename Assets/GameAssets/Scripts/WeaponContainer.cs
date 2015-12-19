using UnityEngine;
using System.Collections;
using SimpleJSON;

public class WeaponContainer {
	
	public bool automatic;
	public bool hitscan;
	public bool projectile;
	public float reloadTime;
	public float shotInterval;
	public int clipSize;
	public int currentAmmo;
	public int damage;
	public int reserveAmmo;	// make sure to reset this when killed and when weapon is swapped
	public int reserveAmmoMax;

	// Constructor when no arguments are passed
	public WeaponContainer () {
	}
	// Initialize weapon
	public WeaponContainer (JSONNode wep) {
		SetValues(wep);
	}

	public void SetValues (JSONNode wep) {
		clipSize = wep ["ammoClip"].AsInt;
		currentAmmo = clipSize;
		reserveAmmoMax = wep ["ammoReserveMax"].AsInt;
		reserveAmmo = reserveAmmoMax;
		automatic = wep ["automatic"].AsBool;
		damage = wep ["damage"].AsInt;
		hitscan = wep ["hitscan"].AsBool;
		reloadTime = wep ["reloadTime"].AsFloat;
		shotInterval = wep ["shotInterval"].AsFloat;
	}
}

