using UnityEngine;
using System.Collections;

public class TweakADS : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Quaternion zoomRot = Quaternion.Euler (0, 0, 0);
	private Quaternion hipRot;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		hipRot = transform.localRotation;
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		if(Input.GetButton ("Fire2")) {
			//transform.localRotation = Quaternion.Lerp (transform.localRotation, zoomRot, Time.deltaTime * 2);
		} else {
			//transform.localRotation = Quaternion.Lerp (transform.localRotation, hipRot, Time.deltaTime * 2);
			
		}
	}
}
