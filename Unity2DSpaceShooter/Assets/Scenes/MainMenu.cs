using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject playButton;

	public void LoadScene()
	{
		SceneManager.LoadScene ("GameEngine");
	}
}
