using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Canvas quitMenu;
	public Canvas optionsMenu;
	public Canvas sbrowserMenu;
	public Canvas loadoutTab;
	public Canvas loadoutTabWepSelect;
	public Canvas inventoryTab;
	public Canvas mainMenu;

	public Button sbrowserClick;
	public Button exitClick;
	public Button optionsClick;
	public Button loadoutTabClick;
	public Button inventoryTabClick;
	public Button loadoutMenuBack;
	public Button inventoryMenuBack;
	public Button navLeftClick;
	public Button navRightClick;

	public Text inventoryPageNumber;
	public int currInventoryPage = 1;					// Link with json player data (retrieve items on current page)
	public int numberOfInventoryPages = 3;				// Link with json player data (retrive number of possible pages)

	public Text loadoutNumber;
	public int currLoadout = 1;						// Link with json player data (retrieve loadout weapons that were equipped)		 				
	public int numberOfLoadouts = 3;				// Link with json player data (retrive number of loadouts the user has)

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		quitMenu.enabled = false;
		loadoutTab.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
		inventoryTab.enabled = false;
		loadoutTabWepSelect.enabled = false;
		mainMenu.enabled = true;

		quitMenu = quitMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		sbrowserMenu = sbrowserMenu.GetComponent<Canvas> ();
		loadoutTab = loadoutTab.GetComponent<Canvas> ();
		inventoryTab = inventoryTab.GetComponent<Canvas> ();
		mainMenu = mainMenu.GetComponent<Canvas> ();
		loadoutTabWepSelect = loadoutTabWepSelect.GetComponent<Canvas> ();

		optionsClick = optionsClick.GetComponent<Button> ();
		loadoutTabClick = loadoutTabClick.GetComponent<Button> ();
		sbrowserClick = sbrowserClick.GetComponent<Button> ();
		exitClick = exitClick.GetComponent<Button> ();
		
		inventoryPageNumber.text = currInventoryPage.ToString() + " / " + numberOfInventoryPages;
		loadoutNumber.text = currLoadout.ToString() + " / " + numberOfLoadouts;
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

	public void exitNoPress() {
		sbrowserClick.enabled = true;
		exitClick.enabled = true;
		loadoutTab.enabled = true;
		optionsClick.enabled = true;

		quitMenu.enabled = false;
		loadoutTab.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
	}

	public void exitYesPress() {
		Application.Quit();
	}

	public void serverMenuPress() {
		quitMenu.enabled = false;
		loadoutTab.enabled = false;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = true;
	}

	public void optionsMenuPress() {
		quitMenu.enabled = false;
		loadoutTab.enabled = false;
		optionsMenu.enabled = true;
		sbrowserMenu.enabled = false;
	}

	public void playerMenuPress() {
		quitMenu.enabled = false;
		loadoutTab.enabled = true;
		optionsMenu.enabled = false;
		sbrowserMenu.enabled = false;
		mainMenu.enabled = false;
	}

	public void pMenuBackPress() {
		mainMenu.enabled = true;
		loadoutTab.enabled = false;
		inventoryTab.enabled = false;

		currInventoryPage = 1;
		currLoadout = 1;
		inventoryPageNumber.text = currInventoryPage.ToString() + " / " + numberOfInventoryPages;
		loadoutNumber.text = currLoadout.ToString() + " / " + numberOfLoadouts;
	}

	public void wepSelectBackPress() {
		loadoutTab.enabled = true;
		loadoutTabWepSelect.enabled = false;
	}
	
	public void inventoryTabPress() {
		mainMenu.enabled = false;
		loadoutTab.enabled = false;
		inventoryTab.enabled = true;
		// load first page of users inventory
	}
	
	public void loadoutTabPress() {
		mainMenu.enabled = false;
		loadoutTab.enabled = true;
		inventoryTab.enabled = false;
		// load user loadout #1
	}

	public void loadoutTabWepSelectPress() {
		loadoutTab.enabled = false;
		loadoutTabWepSelect.enabled = true;
	}
	
	public void navLeftPress() {
		if (currInventoryPage > 1) {
			//loadPrevPage();
			currInventoryPage -= 1;
		} 
		
		inventoryPageNumber.text = currInventoryPage.ToString() + " / " + numberOfInventoryPages;
	}
	
	public void navRightPress() {
		if (currInventoryPage < numberOfInventoryPages) {
			//loadNextPage();
			currInventoryPage += 1;
		} 
		
		inventoryPageNumber.text = currInventoryPage.ToString() + " / " + numberOfInventoryPages;
	}

	public void loadoutNavLeftPress() {
		if (currLoadout > 1) {
			//loadPrevLoadout();
			currLoadout -= 1;
		} 
		
		loadoutNumber.text = currLoadout.ToString() + " / " + numberOfLoadouts;
	}
	
	public void loadoutNavRightPress() {
		if (currLoadout < numberOfLoadouts) {
			//loadNextLoadout();
			currLoadout += 1;
		} 
		
		loadoutNumber.text = currLoadout.ToString() + " / " + numberOfLoadouts;
	}
	
	void loadPrevPage() {
		// Will implement when unique player inventories and cloud storage is a thing...
	}
	
	void loadNextPage() {
		// Will implement when unique player inventories and cloud storage is a thing...
	}

	void loadPrevLoadout() {
		// Will implement when unique player inventories and cloud storage is a thing...
	}
	
	void loadNextLoadout() {
		// Will implement when unique player inventories and cloud storage is a thing...
	}
}