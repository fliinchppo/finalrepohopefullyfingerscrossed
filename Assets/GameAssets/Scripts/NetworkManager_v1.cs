using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;

public class NetworkManager_v1 : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	private const string roomName = "RoomName";
	private RoomInfo[] roomsList;
	public Camera standbyCamera;
	PlayerSpawn[] spawnSpots;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		PhotonNetwork.ConnectUsingSettings("arenafps 0.1");
		spawnSpots = GameObject.FindObjectsOfType<PlayerSpawn> ();
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
	
	}

	void OnGUI() {
		if (!PhotonNetwork.connected) {
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		} else if (PhotonNetwork.room == null) {
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
		Debug.Log("Connected to: " + roomName.ToString());

		// Spawn Player
		SpawnPlayer ();
	}

	void OnPhotonRandomJoinFailed() {
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
	}

	void SpawnPlayer() {
		if (spawnSpots == null) {
			Debug.LogError ("no spawn spots lol, add some noob");
			return;
		}

		PlayerSpawn mySpawnSpot = spawnSpots[ Random.Range (0, spawnSpots.Length) ];
		GameObject myPlayerGameObj = (GameObject) PhotonNetwork.Instantiate ("player", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		standbyCamera.enabled = false;
		myPlayerGameObj.GetComponent<PlayerShooting> ().enabled = true;
		myPlayerGameObj.GetComponent<MouseLook> ().enabled = true;
		myPlayerGameObj.GetComponent<PlayerController> ().enabled = true;
		myPlayerGameObj.GetComponent<GameUI> ().enabled = true;
		myPlayerGameObj.GetComponent<WeaponSwap> ().enabled = true;
		myPlayerGameObj.transform.FindChild ("playerCamera").gameObject.SetActive (true);
	}
}