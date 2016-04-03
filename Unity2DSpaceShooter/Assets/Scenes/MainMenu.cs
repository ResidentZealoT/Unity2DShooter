using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject playButton;

	// chanmge to game screen
	public void LoadScene()
	{
		SceneManager.LoadScene ("GameEngine");
	}
}
