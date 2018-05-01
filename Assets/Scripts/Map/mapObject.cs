using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapObject : MonoBehaviour {

	public GameObject towerPanels;
	public GameObject activeTowerMenu;

	// Use this for initialization
	void Start () {
		//print (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		print ("Background was clicked at time: " + Time.time);
		towerPanels.SetActive (false);
		activeTowerMenu.SetActive (false);
	}
}
