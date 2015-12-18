using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {
	private bool wasLocked = false;

	void Start() {

	}

	void OnMouseDown() {
		Screen.lockCursor = true;
	}

	void Update() {
		if (Input.GetKeyDown ("escape")) {
			Screen.lockCursor = false;
		}

		if (!Screen.lockCursor && wasLocked) {
			wasLocked = false;
		} else if (Screen.lockCursor && !wasLocked) {
			wasLocked = true;
		}
	}
}