using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {
	
	public void loadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

	public void openSettings()
	{
		GameObject settings = (GameObject)Instantiate(Resources.Load("Prefabs/settingsMenu"));
		settings.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
	}

	public void quitScene()
	{
		Application.Quit ();
	}
}
