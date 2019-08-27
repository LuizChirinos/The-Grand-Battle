using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ChangeScene : MonoBehaviour {

	public void Load(string scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void Pause()
	{
		Time.timeScale = 0f;
	}

	public void Unpause()
	{
		Time.timeScale = 1f;
	}

	public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		if (EditorApplication.isPlaying)
		{
			EditorApplication.isPlaying = false;
		}
		#endif

		Application.Quit();
	}

}
