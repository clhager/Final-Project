using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour {

	public GameObject currentSlot;
	public GameObject towerManager;
	public GameObject[] towerPanels;
	public int number;

    private void Awake()
    {
        towerPanels[0].GetComponent<TowerPanel>().element_type = 0;
		try {
	        towerPanels[1].GetComponent<TowerPanel>().element_type = 1;
	        towerPanels[2].GetComponent<TowerPanel>().element_type = 2;
		} catch {
		}
		if (number == 0) {
			towerPanels [0].GetComponent<TowerPanel> ().number = 0;
			try {
				towerPanels [1].GetComponent<TowerPanel> ().number = 0;
				towerPanels [2].GetComponent<TowerPanel> ().number = 0;
			} catch {
			}
		}
    }
}
