using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject playButton;
	public GameObject playerShip;
	public GameObject enemySpawner;
	public GameObject GameOverGO;

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
	}

	GameManagerState GMState;

	// Use this for initialization
	void Start () {
	
		GMState = GameManagerState.Opening;
	}
	
	void UpdateGameManagerState()
	{
		switch (GMState) {
		case GameManagerState.Opening:
			playButton.SetActive (true);
			GameOverGO.SetActive (false);
			break;
		case GameManagerState.Gameplay:
			playButton.SetActive (false);
			playerShip.GetComponent<PlayerControl> ().Init ();
			enemySpawner.GetComponent<EnemySpawner> ().ScheduleEnemySpawner ();
			break;
		case GameManagerState.GameOver:
			GameOverGO.SetActive (true);
			enemySpawner.GetComponent<EnemySpawner> ().UnscheduleEnemySpawner ();
			Invoke ("ChangeToOpeningState", 8f); 

			break;
		}
	}

	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState ();
	}

	public void StartGamePlay()
	{
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState ();
	}

	public void ChangeToOpeningState()
	{
		SetGameManagerState (GameManagerState.Opening);
	}
			
}
