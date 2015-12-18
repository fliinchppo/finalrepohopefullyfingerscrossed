﻿using UnityEngine;
using System.Collections;

public class NetworkCharacter : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
	
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
	
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			//-------This is our player, and we need to send our position to the network----------------------------------------------------------------------------------------
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);

		} else {
			//-------This is someone elses player position, and we need to recieve their position as of x miliseconds ago-------------------------------------------------------
			transform.position = stream.SendNext(transform.position);

		}
	}
}
