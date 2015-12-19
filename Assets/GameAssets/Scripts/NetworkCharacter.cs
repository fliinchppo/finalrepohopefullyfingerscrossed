using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {
	//-------Declare variables-------------------------------------------------------------------------------------------------------------------------
	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;
	public float smoothingParam = 0.1f; // how often position updates 
	Animator anim;


	//-------Use this for initialization---------------------------------------------------------------------------------------------------------------
	void Start () {
		anim = GetComponent<Animator> ();
		if (anim == null) {
			Debug.LogError ("no animator component attached to prefab");
		}
	}
	
	//-------Update is called once per frame-----------------------------------------------------------------------------------------------------------
	void Update() {	
		if (photonView.isMine) {
			//do nothing, as input script is moving us.
		} else {
			transform.position = Vector3.Lerp (transform.position, realPosition, smoothingParam);
			transform.rotation = Quaternion.Lerp (transform.rotation, realRotation, smoothingParam);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			//-------This is our player, and we need to send our position to the network---------------------------------------------------------------
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
			stream.SendNext (anim.GetFloat("Vspeed"));
			stream.SendNext (anim.GetFloat("Hspeed"));
			//stream.SendNext (anim.GetBool("Jumping"));

		} else {
			//-------This is someone elses player position, and we need to recieve their position as of a few miliseconds ago--------------------------
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
			anim.SetFloat("Vspeed", (float) stream.ReceiveNext ());
			anim.SetFloat("Hspeed", (float) stream.ReceiveNext ());
		}
	}
}