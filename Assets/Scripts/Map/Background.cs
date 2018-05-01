using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	private GameObject buildTowerMenu;
	private GameObject activeTowerMenu;

	void Start () {
		buildTowerMenu = GetComponentInParent<Map> ().buildTowerMenu;
		activeTowerMenu = GetComponentInParent<Map> ().activeTowerMenu;
	}

	void OnMouseDown() {
		print ("Background clicked at " + Time.time);
		// Deselect Tower Menus
		buildTowerMenu.SetActive (false);
		activeTowerMenu.SetActive (false);
	}
}
