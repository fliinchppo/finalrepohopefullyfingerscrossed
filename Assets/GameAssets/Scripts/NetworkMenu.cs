using UnityEngine;
using System.Collections;

public class NetworkMenu : MonoBehaviour {
	public string connectionIP = "127.0.0.1";
	public int connectionPort = 8632;
	private bool connected = false;
	
	private void OnConnectedToServer() {
		// A client has just connected
		connected = true;
	}
	
	private void OnServerInitialized() {
		// A server has just been initialized
		connected = true;
	}
	
	private void OnDisconenctedFromServer() {
		// The connection has been terminated
		connected = false;
	}
	
	private void onGUI() {
		if (!connected) {
			connectionIP = GUILayout.TextField(connectionIP);
			int.TryParse(GUILayout.TextField(connectionPort.ToString()), out connectionPort);
			
			if (GUILayout.Button("Connect")) {
				Network.Connect(connectionIP, connectionPort);
			}
			
			if (GUILayout.Button("Host")) {
				Network.InitializeServer(6, connectionPort, true);     // Network.InitializeServer(<number of connections trying to connect>, <port>); 
			}
		} else {
			GUILayout.Label("Connections: " + Network.connections.Length.ToString());
		}
	}
}