using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPanel : MonoBehaviour {
	public Map mapManager;
    public int number;
	public GameObject tower;
    public int element_type;

	void Start() {
		mapManager = GameObject.Find ("MapManager").GetComponent<Map>();
	}

	void OnMouseDown() {

		// Remove Tower
		if (!tower) {
			GameObject towerToRemove = GetComponentInParent<TowerMenu> ().currentSlot;
			GameObject slot = towerToRemove.GetComponent<Tower> ().buildSlot;
			transform.parent.gameObject.SetActive (false);
			Destroy (towerToRemove);
			slot.SetActive (true);

		}
		// Build Tower
		else {
			int cost;
			if (number == 0) {
				cost = 20;
			} else {
				cost = 35;
			}
			if (mapManager.moneys >= cost) {
				mapManager.moneys -= cost;
				mapManager.budget.text = string.Format ("{0}", mapManager.moneys);
				GameObject currentSlot = GetComponentInParent<TowerMenu> ().currentSlot;
				transform.parent.gameObject.SetActive (false);
				currentSlot.SetActive (false);
				Vector3 towerPosition = currentSlot.transform.position;
				if (number == 0 && element_type == 0) {
					towerPosition.y += 0.3f;
				}
				if (number == 1 && element_type == 0) {
					towerPosition.y += 0.5f;
				}
				if (number == 0 && element_type == 1) {
					towerPosition.y += 0.0f;
				}
				if (number == 1 && element_type == 1) {
					towerPosition.y += 0.6f;
				}
				if (number == 0 && element_type == 2) {
					towerPosition.y += 0.5f;
				}
				if (number == 1 && element_type == 2) {
					towerPosition.y += 1.2f;
				}
				towerPosition.z = 2;
				GameObject towerClone = Instantiate (tower, towerPosition, Quaternion.identity);
				towerClone.GetComponent<Tower> ().buildSlot = currentSlot;
				towerClone.GetComponent<Tower> ().type = element_type;
				towerClone.GetComponent<Tower> ().number = number;
			}
        }

	}
}
