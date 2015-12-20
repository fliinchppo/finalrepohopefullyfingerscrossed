using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMenu : MonoBehaviour {
	//-------Declare variables--------------------------------------------------------------------------------------------------------------------------------------------------
	public Canvas mainMenu;
	public Canvas inventoryTab;
	public Canvas loadoutTab;

	public Button back;
	public Button loadoutTabClick;
	public Button inventoryTabClick;
	public Button navLeftClick;
	public Button navRightClick;

	public Text pageNumber;
	public int currPage = 1;					// Link with json player data (retrieve items on current page)
	public int numberOfPages = 3;				// Link with json player data (retrive number of possible pages)

	//-------Use this for initialization----------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		mainMenu = mainMenu.GetComponent<Canvas> ();
		inventoryTab = inventoryTab.GetComponent<Canvas> ();
		loadoutTab = loadoutTab.GetComponent<Canvas> ();

		pageNumber.text = currPage.ToString() + " / " + numberOfPages;
	}
	
	public void backPress() {
		mainMenu.enabled = true;
		loadoutTab.enabled = false;
		inventoryTab.enabled = false;
	}

	public void inventoryPress() {
		mainMenu.enabled = false;
		loadoutTab.enabled = false;
		inventoryTab.enabled = true;
	}

	public void loadoutPress() {
		mainMenu.enabled = false;
		loadoutTab.enabled = true;
		inventoryTab.enabled = false;
	}

	public void navLeftPress() {
		if (currPage > 1) {
			//loadPrevPage();
			currPage -= 1;
		} 

		pageNumber.text = currPage.ToString() + " / " + numberOfPages;
	}

	public void navRightPress() {
		if (currPage < numberOfPages) {
			//loadNextPage();
			currPage += 1;
		} 

		pageNumber.text = currPage.ToString() + " / " + numberOfPages;
	}

	void loadPrevPage() {
		// Will implement when unique player inventories and cloud storage is a thing...
	}

	void loadNextPage() {
		// Will implement when unique player inventories and cloud storage is a thing...
	}
}
