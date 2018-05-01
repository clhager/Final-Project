using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {

	public GameObject buildTowerMenu;
	public GameObject activeTowerMenu;
	public GameObject pauseMenu;
	public bool pauseOn;

	public Text budget;
	public int moneys;

	void Start() {
		pauseOn = false;
		moneys = 50;
		budget.text = string.Format ("{0}", moneys);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseOn = !pauseOn;
			pauseMenu.SetActive (pauseOn);
		}
	}
}
