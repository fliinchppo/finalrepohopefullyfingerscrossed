using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Canvas quitMenu;
	public Canvas optionsMenu;
	public Canvas sbrowserMenu;
	public Canvas loadoutTab;
	public Canvas inventoryTab;

	public Button sbrowserClick;
	public Button exitClick;
	public Button optionsClick;
	public Button loadoutTabClick;
	public Button inventoryTabClick;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		quitMenu.enabled = false;
		loadoutTab.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
		inventoryTab.enabled = false;

		quitMenu = quitMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		sbrowserMenu = sbrowserMenu.GetComponent<Canvas> ();
		loadoutTab = loadoutTab.GetComponent<Canvas> ();
		inventoryTab = inventoryTab.GetComponent<Canvas> ();

		optionsClick = optionsClick.GetComponent<Button> ();
		loadoutTabClick = loadoutTabClick.GetComponent<Button> ();
		sbrowserClick = sbrowserClick.GetComponent<Button> ();
		exitClick = exitClick.GetComponent<Button> ();
	}
	
	public void exitPress() {
		sbrowserClick.enabled = false;
		exitClick.enabled = false;
		loadoutTab.enabled = false;
		optionsClick.enabled = false;

		quitMenu.enabled = true;
		loadoutTab.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
	}

	public void noPress() {
		sbrowserClick.enabled = true;
		exitClick.enabled = true;
		loadoutTab.enabled = true;
		optionsClick.enabled = true;

		quitMenu.enabled = false;
		loadoutTab.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
	}

	public void exit() {
		Application.Quit();
	}

	public void serversPress() {
		quitMenu.enabled = false;
		loadoutTab.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = true;
	}

	public void optionsPress() {
		quitMenu.enabled = false;
		loadoutTab.enabled = false;
		optionsMenu.enabled = true;
		sbrowserMenu.enabled = false;
	}

	public void playerPress() {
		quitMenu.enabled = false;
		loadoutTab.enabled = true;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
	}
}
