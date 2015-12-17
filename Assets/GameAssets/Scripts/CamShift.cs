using UnityEngine;
using System.Collections;

public class CamShift : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Vector3 zoomPos;
	private Vector3 hipPos;
	public GameObject crosshairHide;
	private float aim;
	public float aimSpeed;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		hipPos = transform.localPosition;
		aim = Time.deltaTime * aimSpeed;
	}
	
	//-------Update is called once per frame------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		//if(Input.GetButton ("Fire2")) {
		//	transform.localPosition = Vector3.Lerp (transform.localPosition, zoomPos, aim);
		//	crosshairHide.GetComponent<GameUI> ().crosshairScale = 0;
		//} else {
		//	transform.localPosition = Vector3.Lerp (transform.localPosition, hipPos, aim);
		//	crosshairHide.GetComponent<GameUI> ().crosshairScale = 1;
		//}
	}
}
