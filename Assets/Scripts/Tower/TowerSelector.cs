using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour {

	private GameObject buildTowerMenu;
	private GameObject activeTowerMenu;
	private GameObject towerManager;

	// Use this for initialization
	void Start () {
		buildTowerMenu = GetComponentInParent<Tower> ().buildTowerMenu;
		activeTowerMenu = GetComponentInParent<Tower> ().activeTowerMenu;
		towerManager = GameObject.Find ("TowerManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {

		// Deactivate the build menu
		buildTowerMenu.SetActive (false);

		// Move the active menu to the tower
		activeTowerMenu.transform.position = this.transform.position;
		TowerMenu upgradeMenu = activeTowerMenu.GetComponent<TowerMenu> ();
		upgradeMenu.currentSlot = this.transform.parent.gameObject;

		// Set the appropriate upgrades
		TowerPanel upgradeA = upgradeMenu.towerPanels[0].GetComponent<TowerPanel> ();
		//TowerPanel upgradeB = upgradeMenu.towerPanels[1].GetComponent<TowerPanel> ();
		bool upgradeable = false;
		if (GetComponentInParent<Tower> ().number == 0) {
			upgradeA.tower = towerManager.GetComponent<TowerManager> ().getTower (GetComponentInParent<Tower> ().type, 1);
			upgradeA.number = 1;
			upgradeA.element_type = GetComponentInParent<Tower> ().type;
			upgradeable = true;
			//upgradeB.tower = towerManager.GetComponent<TowerManager> ().getTower (GetComponentInParent<Tower> ().element_type, 3);
			//upgradeB.number = 3;
		}
		activeTowerMenu.GetComponent<TowerMenu> ().number = 1;
		activeTowerMenu.SetActive (true);
		if (!upgradeable) {
			activeTowerMenu.GetComponent<TowerMenu> ().towerPanels [0].SetActive (false);
		} else {
			activeTowerMenu.GetComponent<TowerMenu> ().towerPanels [0].SetActive (true);
		}
	}
}
