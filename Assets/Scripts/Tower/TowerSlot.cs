using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlot : MonoBehaviour {

	private GameObject buildTowerMenu;
	private GameObject activeTowerMenu;

	void Start () {
		buildTowerMenu = GetComponentInParent<Map> ().buildTowerMenu;
		activeTowerMenu = GetComponentInParent<Map> ().activeTowerMenu;
	}

	void OnMouseDown() {
		activeTowerMenu.SetActive (false);
		buildTowerMenu.transform.position = this.transform.position;
		buildTowerMenu.GetComponent<TowerMenu> ().currentSlot = this.gameObject;
		activeTowerMenu.GetComponent<TowerMenu> ().number = 0;
		activeTowerMenu.GetComponent<TowerMenu> ().currentSlot = this.gameObject;
		buildTowerMenu.SetActive (true);
	}
}
