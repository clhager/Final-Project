using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public RectTransform five1;
	public RectTransform five2;
	public RectTransform four1;
	public RectTransform four2;
	public RectTransform three1;
	public RectTransform three2;

	public int rate51;
	public int rate52;
	public int rate41;
	public int rate42;
	public int rate31;
	public int rate32;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		five1.localPosition += (Vector3.right * Time.deltaTime * rate51);
		five2.localPosition += (Vector3.right * Time.deltaTime * rate52);
		four1.localPosition += (Vector3.right * Time.deltaTime * rate41);
		four2.localPosition += (Vector3.right * Time.deltaTime * rate42);
		three1.localPosition += (Vector3.right * Time.deltaTime * rate31);
		three2.localPosition += (Vector3.right * Time.deltaTime * rate32);

		if (five1.localPosition.x >= 960) {
			five1.localPosition = new Vector3 (-1080, 0, 0);
		}
		if (five2.localPosition.x >= 840) {
			five2.localPosition = new Vector3 (-920, 0, 0);
		}
		if (four1.localPosition.x >= 920) {
			four1.localPosition = new Vector3 (-980, 0, 0);
		}
		if (four2.localPosition.x >= 1220) {
			four2.localPosition = new Vector3 (-1180, 0, 0);
		}
		if (three1.localPosition.x >= 780) {
			three1.localPosition = new Vector3 (-1190, 0, 0);
		}
		if (three2.localPosition.x >= 1220) {
			three2.localPosition = new Vector3 (-1080, 0, 0);
		}
	}
}
