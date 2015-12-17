using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public static GameController control;

	public int health;

	//-------Awake is before Start----------------------------------------------------------------------------------------------------------------------------------------------
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy(gameObject);
		}
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void OnGUI () {
		GUI.Label (new Rect (10, 10, 100, 30), "Health: " + health);
	}
}
