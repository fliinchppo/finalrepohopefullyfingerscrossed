using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sbMenu : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Button debug_server1;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		
	}

	public void server1Press() {
		Application.LoadLevel (1);
	}
}
