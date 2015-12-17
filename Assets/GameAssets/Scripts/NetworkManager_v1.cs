using UnityEngine;
using System;
using System.Collections;

public class NetworkManager_v1 : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	private const string roomName = "RoomName";
	private RoomInfo[] roomsList;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
	
	}

	void OnGUI() {
		if (!PhotonNetwork.connected) {
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		}
		else if (PhotonNetwork.room == null) {
			// Create Room
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server")) {
				PhotonNetwork.CreateRoom(roomName + Guid.NewGuid().ToString("N"), new RoomOptions() { maxPlayers = 10}, null);
			}
			
			// Join Room
			if (roomsList != null) {
				for (int i = 0; i < roomsList.Length; i++) {
					if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].name)) {
						PhotonNetwork.JoinRoom(roomsList[i].name);
					}
				}
			}
		}
	}
	
	void OnReceivedRoomListUpdate()	{
		roomsList = PhotonNetwork.GetRoomList();
	}
	void OnJoinedRoom() {
		Debug.Log("Connected to Room");

		// Spawn Player
		PhotonNetwork.Instantiate ("player", Vector3.up * 5, Quaternion.identity, 0);
	}
}
