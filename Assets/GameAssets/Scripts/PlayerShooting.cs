using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	//-------Declare variables-----------------------------
	public Animator anim;
	public AudioClip gun_fire;
	public float ejectSpeed;
	public float gunRange;
	public GameObject bulletCasing;
	public GameObject clone;
	public GameObject impactPrefab;
	public Text ammmagtxt;
	public Text ammvaltxt;
	public RaycastHit hitInfo;
	public WeaponContainer cW;

	private AudioSource sndSource;
	private bool animFinished = true;
	private bool canShoot = true;
	private float shotTime;
	private int bulletsShot;
	private int totalAmmo;
	private Rigidbody cloneRB;	

	//GameObject[] impacts;
	//int currentImpacts = 0;
	//int maxImpacts = 5;



	//public Animation weaponAnim; 

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
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

		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, gunRange)) {
			if (hitInfo.transform.tag == "wall") {  
				Debug.Log("shot " + hitInfo.transform.tag + " for " + cW.damage + " damage.");
			}

			if (hitInfo.transform.tag == "terrain")	{  
				Debug.Log("shot " + hitInfo.transform.tag + " for " + cW.damage + " damage.");
			}

			//if (hitInfo.transform.tag == "enemy") {  
			//	enemy hp = hitInfo.collider.GetComponent<enemy>();
				//if (hp != null) {
				//	hp.applyDamage (damage, hitInfo.point);
				//}
			//	hitInfo.collider.gameObject.SendMessage("applyDamage", damage);
			//	Debug.Log("shot " + hitInfo.transform.tag + " for " + damage + " damage.");
			//}
		}
	}

	void projectileShot() {
		// code this later lol, cbf atm
	}

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

