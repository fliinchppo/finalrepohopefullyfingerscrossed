using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public AudioClip gun_fire;
	private AudioSource sndSource;
	private bool canShoot = true;
	private bool animFinished = true;
	public bool hitscan;
	public bool projectile;
	public int damage;
	private int currentAmmo;
	public int clipSize;
	public int reserveAmmo;
	private int totalAmmo;
	private int bulletsShot;				// make sure to reset this when killed and when weapon is swapped
	public float shotInterval = 0.3f;
	public float gunRange;
	public float ejectSpeed; 
	public float reloadTime; 
	private float shotTime;
	public Text ammvaltxt;
	public Text ammmagtxt;
	public RaycastHit hitInfo;
	public GameObject bulletCasing; 
	public GameObject clone; 
	private Rigidbody cloneRB;

	public Animator anim;
	public GameObject impactPrefab;

	//GameObject[] impacts;
	//int currentImpacts = 0;
	//int maxImpacts = 5;



	//public Animation weaponAnim; 

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		ammvaltxt = GameObject.Find ("amm_val").GetComponent<Text> ();

		currentAmmo = clipSize;
		sndSource = GetComponent<AudioSource>();
		ammvaltxt.text = currentAmmo.ToString();
		ammmagtxt.text = reserveAmmo.ToString();
		bulletsShot = 0;

		//impacts = new GameObject[maxImpacts];
		//for (int i = 0; i < maxImpacts; i++) {
		//	impacts[i] = (GameObject)Instantiate(impactPrefab);
		//}
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void FixedUpdate () {
		if (Input.GetButton ("Fire1") && Time.time > shotTime && currentAmmo > 0 && canShoot == true && !Input.GetButton ("Sprint")) {
			gameObject.GetComponent<Animation> ().Play ("glock_fire");
			shoot ();
			shotTime = Time.time + shotInterval; // reset shot time
			// casingEject();
			canShoot = false; 
		}

		if ((Input.GetButtonDown ("Reload") || currentAmmo == 0)&& currentAmmo != clipSize && reserveAmmo != 0) {
			// play animation when called

			print ("Reloading");

			ammvaltxt = GameObject.Find ("amm_val").GetComponent<Text> ();

			totalAmmo = clipSize + reserveAmmo;
			if (totalAmmo <= clipSize) {
				currentAmmo = totalAmmo;
				reserveAmmo = 0;
			} else {
				bulletsShot = clipSize - currentAmmo;
				currentAmmo = clipSize;
				reserveAmmo -= bulletsShot;
			}

			ammvaltxt.text = currentAmmo.ToString();
			ammmagtxt.text = reserveAmmo.ToString();
			shotTime = Time.time + reloadTime;
		}

		if (Time.time > shotTime) {
			canShoot = true;
		}
	}

	void shoot() {
		if (hitscan == true) {
			hitscanShot ();
		} else if (projectile == true) {
			// projectileShot();
		} else {
		}
	}

	void hitscanShot() {
		currentAmmo -= 1;
		ammvaltxt = GameObject.Find ("amm_val").GetComponent<Text> ();
		ammvaltxt.text = currentAmmo.ToString();
		ammmagtxt.text = reserveAmmo.ToString();
		sndSource.PlayOneShot (gun_fire); 

		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, gunRange)) {
			if (hitInfo.transform.tag == "wall") {  
				Debug.Log("shot " + hitInfo.transform.tag + " for " + damage + " damage.");
			}

			if (hitInfo.transform.tag == "terrain")	{  
				Debug.Log("shot " + hitInfo.transform.tag + " for " + damage + " damage.");
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
}
