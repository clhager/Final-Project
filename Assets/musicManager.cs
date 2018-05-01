using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour {

	public GameObject source;

	// Use this for initialization
	void Start () {
		StartCoroutine (PlayMusic());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator PlayMusic() {
		yield return new WaitForSeconds (1);
		source.SetActive (true);
	}
}
