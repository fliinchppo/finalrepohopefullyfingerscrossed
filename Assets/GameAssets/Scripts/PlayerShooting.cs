using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class PlayerShooting : MonoBehaviour {
	//-------Declare variables-----------------------------
	public Animator anim;
	public AudioClip gun_fire;
	public float ejectSpeed;
	public float gunRange;
	public GameObject bulletCasing;
	public GameObject clone;
	public GameObject impactPrefab;
	public string loadoutWeapon1;
	public string loadoutWeapon2;
	public Text ammmagtxt;
	public Text ammvaltxt;
	public RaycastHit hitInfo;
	public WeaponContainer cW = new WeaponContainer ();
	
	private AudioSource sndSource;
	private bool animFinished = true;
	private bool canShoot = true;
	private float shotTime;
	private int bulletsShot;
	private int totalAmmo;
	private int wSlot = 0;
	private List<WeaponContainer> weapons = new List<WeaponContainer>();
	private Rigidbody cloneRB;	

	//GameObject[] impacts;
	//int currentImpacts = 0;
	//int maxImpacts = 5;

	//public Animation weaponAnim; 

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		TextAsset jsonList = Resources.Load ("weaponsList") as TextAsset; // Load weapons list json file
		var weaponList = JSON.Parse (jsonList.text); // Parse weapon file

		loadoutWeapon1 = "assaultRifle";
		loadoutWeapon2 = "pistol";
		
		// Get chosen loadout weapons and store as WeaponContainer class

		WeaponContainer w1 = new WeaponContainer (weaponList [loadoutWeapon1]);
		WeaponContainer w2 = new WeaponContainer (weaponList [loadoutWeapon2]);
		
		// Add WeaponContainers to weapons list
		weapons.Add (w1);
		weapons.Add (w2);
		
		SetWeapon (0); // Equip weapon in wSlot 0

		ammvaltxt = GameObject.Find ("amm_val").GetComponent<Text> ();
		ammmagtxt = GameObject.Find ("amm_mag").GetComponent<Text> ();

		sndSource = GetComponent<AudioSource>();
		UpdateHUD ();
		bulletsShot = 0;

		//impacts = new GameObject[maxImpacts];
		//for (int i = 0; i < maxImpacts; i++) {
		//	impacts[i] = (GameObject)Instantiate(impactPrefab);
		//}


	}

	void Update () {
		Swap ();
	}

	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void FixedUpdate () {

		if (Input.GetButton ("Fire1") && cW.currentAmmo > 0 && canShoot == true && !Input.GetButton ("Sprint")) {
			gameObject.GetComponent<Animation> ().Play ("glock_fire");
			shoot ();
			shotTime = Time.time + cW.shotInterval; // reset shot time
			// casingEject();
			canShoot = false; 
		}

		if ((Input.GetButtonDown ("Reload") || cW.currentAmmo == 0)&& cW.currentAmmo != cW.clipSize && cW.reserveAmmo != 0) {
			// play animation when called

			print ("Reloading");
			ammvaltxt = GameObject.Find ("amm_val").GetComponent<Text> ();
			ammmagtxt = GameObject.Find ("amm_mag").GetComponent<Text> ();

			totalAmmo = cW.clipSize + cW.reserveAmmo;
			if (totalAmmo <= cW.clipSize) {
				cW.currentAmmo = totalAmmo;
				cW.reserveAmmo = 0;
			} else {
				bulletsShot = cW.clipSize - cW.currentAmmo;
				cW.currentAmmo = cW.clipSize;
				cW.reserveAmmo -= bulletsShot;
			}

			ammvaltxt.text = cW.currentAmmo.ToString();
			ammmagtxt.text = cW.reserveAmmo.ToString();
			shotTime = Time.time + cW.reloadTime;
		}

		if (cW.automatic == true) { // Checks if weapon is automatic, if true, can hold down fire button to shoot
			if (Time.time > shotTime) {
				canShoot = true;
			}
		} else if (Input.GetButtonUp ("Fire1")) { // Else you have to let go of the button to fire another shot
			canShoot = true;
		}
	}
	
	void SetWeapon (int w) { // Set the current weapon to weapons [w]

		cW = weapons [w];
		
		UpdateHUD ();
		SwapWeaponPrefab ();
		
		Debug.Log (w);
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

	void SwapWeaponMesh () {
		var gun = transform.Find("playerCamera/weaponController/AssaultRifle").gameObject;
		Mesh mesh = (Mesh)Resources.Load(cW.modelURL,typeof(Mesh));
		gun.GetComponent<MeshFilter>().mesh = mesh;
	}

	void SwapWeaponPrefab () {
		int otherWeapon = 1;
		if (wSlot == 1) {
			otherWeapon = 0;
		}

		var swapFrom = transform.Find("HQBodyModel/ParentObject/Armature/LowerBody/Spine/UpperBody_0/Shoulder_R/UpperArm_R_0/LowerArm_R_0/Hand_R/weaponController/" + weapons[otherWeapon].prefab).gameObject;
		var swapTo = transform.Find("HQBodyModel/ParentObject/Armature/LowerBody/Spine/UpperBody_0/Shoulder_R/UpperArm_R_0/LowerArm_R_0/Hand_R/weaponController/" + cW.prefab).gameObject;
		Debug.Log (swapTo.ToString());

		swapFrom.SetActive (false);
		swapTo.SetActive (true);
	}
	
	void shoot() {
		if (cW.hitscan == true) {
			hitscanShot ();
		} else if (cW.projectile == true) {
			// projectileShot();
		} else {
		}
	}

	void hitscanShot() {
		cW.currentAmmo -= 1;
		ammvaltxt = GameObject.Find ("amm_val").GetComponent<Text> ();
		ammmagtxt = GameObject.Find ("amm_mag").GetComponent<Text> ();

		UpdateHUD ();
		sndSource.PlayOneShot (gun_fire); 

		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, gunRange)) {
			if (hitInfo.transform.tag == "wall") {  
				Debug.Log ("shot " + hitInfo.transform.tag + " for " + cW.damage + " damage.");
			}

			if (hitInfo.transform.tag == "terrain") {  
				Debug.Log ("shot " + hitInfo.transform.tag + " for " + cW.damage + " damage.");
			}

			/* if (hitInfo.transform.tag == "enemy") {
				Debug.Log ("shot " + hitInfo.transform.tag + " for " + cW.damage + " damage.");
				----APPLY DAMAGE TO TARGET PLAYER
					----IF TARGET PLAYER'S HEALTH < WEAPON DAMAGE
						----UPDATE KILL FEED, SEND DEATH MESSAGE TO TARGET
					----ELSE, TARGET PLAYER'S HEALTH -= WEAPON DAMAGE
			}
			*/
		}
	}

	void projectileShot() {
		// code this later lol, cbf atm
	}

	// broken function, only clientside
	void casingEject() {
		clone = Instantiate (bulletCasing, transform.position, transform.rotation) as GameObject;
		cloneRB = bulletCasing.GetComponent<Rigidbody> ();
		cloneRB.velocity = transform.TransformDirection (Vector3.right * ejectSpeed);
	}

	public void UpdateHUD() {
		ammvaltxt = GameObject.Find ("amm_val").GetComponent<Text> ();
		ammmagtxt = GameObject.Find ("amm_mag").GetComponent<Text> ();
		ammvaltxt.text = cW.currentAmmo.ToString();
		ammmagtxt.text = cW.reserveAmmo.ToString();
	}
}
