using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{

	public GameObject EnemyGO;

	// how fast the enemies spawn
	float SpawnRate = 0.5f;

	// randomly spawns enemy at the top of the screen
	void SpawnEnemy ()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject EnemyInstance = (GameObject)Instantiate (EnemyGO);
		EnemyInstance.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		ScheduleSpawn ();
	}

	// handles the next spawn when timer reached
	void ScheduleSpawn()
	{
		float spawn;

		if (SpawnRate > 0.5f) {
			spawn = Random.Range (0.5f, SpawnRate);
		} else
			spawn = 0.5f;

		Invoke ("SpawnEnemy", spawn);
	}

	// increases spawn rate
	void IncreaseDIfficulty()
	{
		if (SpawnRate > 0.5f)
			SpawnRate--;
		if (SpawnRate == 0.5f)
			CancelInvoke ("IncreaseDifficulty");
			
	}

	public void ScheduleEnemySpawner()
	{
		Invoke ("SpawnEnemy", SpawnRate);

		InvokeRepeating ("IncreaseDifficulty", 0f, 30f);

			
	}

	public void UnscheduleEnemySpawner()
	{
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncreaseDifficulty");
	}

}
