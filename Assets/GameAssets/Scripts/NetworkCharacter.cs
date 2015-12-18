using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;
	public float smoothingParam = 0.1f; // how often position updates 
	//float lastUpdateTime;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		if (photonView.isMine) {
			//do nothing, as input script is moving us.
		} else {
			transform.position = Vector3.Lerp (transform.position, realPosition, smoothingParam);
			transform.rotation = Quaternion.Lerp (transform.rotation, realRotation, smoothingParam);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			//-------This is our player, and we need to send our position to the network----------------------------------------------------------------------------------------
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);

		} else {
			//-------This is someone elses player position, and we need to recieve their position as of x miliseconds ago-------------------------------------------------------
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
