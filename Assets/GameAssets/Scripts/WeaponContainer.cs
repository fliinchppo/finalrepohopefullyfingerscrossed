using UnityEngine;
using System.Collections;
using SimpleJSON;

public class WeaponContainer : MonoBehaviour {
	
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

	// Use this for initialization
	public WeaponContainer (JSONNode wep) {
		clipSize	= wep ["ammoClip"].AsInt;
		currentAmmo = wep ["ammoClip"].AsInt;
		reserveAmmo    = wep ["ammoReserveMax"].AsInt;
		reserveAmmoMax = wep ["ammoReserveMax"].AsInt;
		automatic = wep ["automatic"].AsBool;
		damage = wep ["damage"].AsInt;
		hitscan = wep ["hitscan"].AsBool;
		reloadTime = wep ["reloadTime"].AsFloat;
		shotInterval = wep ["shotInterval"].AsFloat;
	}
}

