using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

	[Header("Menus")]
	public GameObject buildTowerMenu;
	public GameObject activeTowerMenu;

	[Header("Fire")]
	public GameObject[] FireTowers;
	[Header("Water")]
	public GameObject[] WaterTowers;
	[Header("Energy")]
	public GameObject[] EnergyTowers;

	void Start () {

		// Set up the Tower Panels
		TowerMenu menu = buildTowerMenu.GetComponent<TowerMenu>();
		// Fire
		menu.towerPanels[0].GetComponent<TowerPanel>().tower = FireTowers[0];
		// Water
		menu.towerPanels[1].GetComponent<TowerPanel>().tower = WaterTowers[0];
		// Energy
		menu.towerPanels[2].GetComponent<TowerPanel>().tower = EnergyTowers[0];

	}

	void Update () {
		
		// Register inputs
		if (Input.GetMouseButtonDown (1)) {
			buildTowerMenu.SetActive (false);
			activeTowerMenu.SetActive (false);
		}

	}

	public GameObject getTower(int type, int number) {
		if (type == 0) {
			return FireTowers [number];
		} else if (type == 1) {
			return WaterTowers [number];
		} else if (type == 2) {
			return EnergyTowers [number];
		} else {
			print ("Type not recognized");
			return null;
		}
	}
}
