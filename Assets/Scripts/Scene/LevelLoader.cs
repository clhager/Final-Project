using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider slider;

	public GameObject mainMenu;
	public GameObject levels;

	public void LoadLevel (int sceneIndex) 
	{
		StartCoroutine (LoadAsynchronously (sceneIndex));  
	}

	IEnumerator LoadAsynchronously (int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);
		loadingScreen.SetActive (true);

		while (!operation.isDone) 
		{
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			slider.value = progress;

			yield return null;
		}
	}

	public void QuitGame() {
		Debug.Log ("quit");
		Application.Quit ();
	}

	public void toMainMenu() {
		levels.SetActive (false);
		mainMenu.SetActive (true);
	}

	public void toLevels() {
		mainMenu.SetActive (false);
		levels.SetActive (true);
	}

}
