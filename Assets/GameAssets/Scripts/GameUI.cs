using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Texture2D crosshairTexture;
	public float crosshairScale = 1;
	private bool inMenu = false;
	CursorLockMode wantedMode;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		Screen.lockCursor = true;
		Cursor.visible = true;
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	//-------Apply requested cursor state---------------------------------------------------------------------------------------------------------------------------------------
	void SetCursorState ()
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}

	void OnGUI()
	{
		//-------If game is not paused------------------------------------------------------------------------------------------------------------------------------------------
		if (Time.timeScale != 0) {
			if (crosshairTexture != null) {
				GUI.DrawTexture (new Rect ((Screen.width - crosshairTexture.width * crosshairScale) / 2, (Screen.height - crosshairTexture.height * crosshairScale) / 2, crosshairTexture.width * crosshairScale, crosshairTexture.height * crosshairScale), crosshairTexture);
			} else {
				Debug.Log ("No crosshair texture set in the Inspector");
			}
		}

		//-------Mouse lock script-----------------------------------------------------------------------------------------------------------------------------------------------
		if (Input.GetKeyDown (KeyCode.Escape) && inMenu == false) {
			// open game 'pause' menu
			Cursor.lockState = wantedMode = CursorLockMode.None;
			inMenu = true;
		}

		//if (Input.GetKeyDown (KeyCode.Escape) || if resume button is clicked && inMenu == true) {
		// if pause menu is exited, lock cursor again and disable pause menu
		//wantedMode = CursorLockMode.Locked;
		//SetCursorState ();
		//}
	}
}
