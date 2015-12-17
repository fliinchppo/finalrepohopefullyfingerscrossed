using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadoutMenu : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Image slot1Menu;
	public Image slot2Menu;

	public Text s2o1;
	public Text s2o2;
	public Text s1o1;
	public Text s1o2;
	public Text slot1Text;
	public Text slot2Text;

	public Button slot1Click;
	public Button slot2Click;
	public Button s1o1Click;
	public Button s1o2Click;
	public Button s2o1Click;
	public Button s2o2Click;

	private bool s1isshowing;
	private bool s2isshowing;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		slot1Menu.enabled = false;
		slot2Menu.enabled = false;
		s1o1.enabled = false;
		s1o2.enabled = false;
		s2o1.enabled = false;
		s2o2.enabled = false;

		slot1Menu = slot1Menu.GetComponent<Image> ();
		slot2Menu = slot2Menu.GetComponent<Image> ();

		s1o1 = s1o1.GetComponent<Text> ();
		s1o2 = s1o2.GetComponent<Text> ();
		s2o1 = s2o1.GetComponent<Text> ();
		s2o2 = s2o2.GetComponent<Text> ();
		
		slot1Click = slot1Click.GetComponent<Button> ();
		slot2Click = slot2Click.GetComponent<Button> ();

		slot1Text = slot1Click.GetComponent<Text> ();
		slot2Text = slot2Click.GetComponent<Text> ();

	}
	
	public void slot1Press() {
		s1isshowing = !s1isshowing;

		slot1Click.enabled = true;
		slot2Click.enabled = true;

		s1o1.enabled = s1isshowing;
		s1o2.enabled = s1isshowing;
		s2o1.enabled = false;
		s2o2.enabled = false;

		slot1Menu.enabled = s1isshowing;
		slot2Menu.enabled = false;
	}

	public void slot2Press() {
		s2isshowing = !s2isshowing;

		s2o1Click.enabled = true;
		slot2Click.enabled = true;

		s1o1.enabled = false;
		s1o2.enabled = false;
		s2o1.enabled = s2isshowing;
		s2o2.enabled = s2isshowing;

		slot1Menu.enabled = false;
		slot2Menu.enabled = s2isshowing;
	}

	public void s1o1Press() {
		if (slot2Text.text == s1o1.ToString ()) {
			hideMenu ();
		} else {
			hideMenu ();
			slot1Text.text = s1o1.ToString ();
		}
	}

	public void s1o2Press() {
		if (slot2Text.text == s1o2.ToString ()) {
			hideMenu ();
		} else {
			hideMenu ();
			slot1Text.text = s1o2.ToString ();
		}
	}

	public void s2o1Press() {
		if (slot1Text.text == s2o1.ToString ()) {
			hideMenu ();
		} else {
			hideMenu ();
			slot2Text.text = s2o1.ToString ();
		}
	}

	public void s2o2Press() {
		if (slot1Text.text == s2o2.ToString ()) {
			hideMenu ();
		} else {
			hideMenu ();
			slot2Text.text = s2o2.ToString ();
		}
	}

	public void hideMenu() {
		s2o1Click.enabled = true;
		slot2Click.enabled = true;
		
		s1o1.enabled = false;
		s1o2.enabled = false;
		s2o1.enabled = false;
		s2o2.enabled = false;
		
		slot1Menu.enabled = false;
		slot2Menu.enabled = false;
	}
}
