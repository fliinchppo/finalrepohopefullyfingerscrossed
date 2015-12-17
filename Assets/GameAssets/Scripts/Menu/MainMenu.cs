using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Canvas quitMenu;
	public Canvas loadoutMenu;
	public Canvas optionsMenu;
	public Canvas sbrowserMenu;

	public Button sbrowserClick;
	public Button exitClick;
	public Button loadoutClick;
	public Button optionsClick;

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		quitMenu.enabled = false;
		loadoutMenu.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;

		quitMenu = quitMenu.GetComponent<Canvas> ();
		loadoutMenu = loadoutMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		sbrowserMenu = sbrowserMenu.GetComponent<Canvas> ();

		optionsClick = optionsClick.GetComponent<Button> ();
		loadoutClick = loadoutClick.GetComponent<Button> ();
		sbrowserClick = sbrowserClick.GetComponent<Button> ();
		exitClick = exitClick.GetComponent<Button> ();
	}
	
	public void exitPress() {
		sbrowserClick.enabled = false;
		exitClick.enabled = false;
		loadoutClick.enabled = false;
		optionsClick.enabled = false;
		
		quitMenu.enabled = true;
		loadoutMenu.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
	}

	public void noPress() {
		sbrowserClick.enabled = true;
		exitClick.enabled = true;
		loadoutClick.enabled = true;
		optionsClick.enabled = true;

		quitMenu.enabled = false;
		loadoutMenu.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
	}

	public void exit() {
		Application.Quit();
	}

	public void serversPress() {
		sbrowserClick.enabled = false;
		exitClick.enabled = true;
		loadoutClick.enabled = true;
		optionsClick.enabled = true;
		
		quitMenu.enabled = false;
		loadoutMenu.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = true;
	}

	public void optionsPress() {
		sbrowserClick.enabled = true;
		exitClick.enabled = true;
		loadoutClick.enabled = true;
		optionsClick.enabled = false;
		
		quitMenu.enabled = false;
		loadoutMenu.enabled = false;
		optionsMenu.enabled = true;
		sbrowserMenu.enabled = false;
	}

	public void loadoutPress() {
		sbrowserClick.enabled = true;
		exitClick.enabled = true;
		loadoutClick.enabled = false;
		optionsClick.enabled = true;
		
		quitMenu.enabled = false;
		loadoutMenu.enabled = true;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
	}
}
