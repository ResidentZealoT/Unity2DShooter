using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{

	public GameObject EnemyGO;

	float SpawnRate = 5f;

	// Use this for initialization
	void Start ()
	{
		Invoke ("SpawnEnemy", SpawnRate);

		InvokeRepeating ("IncreaseDifficulty", 0f, 30f);

	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void SpawnEnemy ()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject EnemyInstance = (GameObject)Instantiate (EnemyGO);
		EnemyInstance.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		ScheduleSpawn ();
	}

	void ScheduleSpawn()
	{
		float spawn;

		if (SpawnRate > 1f) {
			spawn = Random.Range (1f, SpawnRate);
		} else
			spawn = 1f;

		Invoke ("SpawnEnemy", spawn);
	}

	void IncreaseDIfficulty()
	{
		if (SpawnRate > 1f)
			SpawnRate--;
		if (SpawnRate == 1f)
			CancelInvoke ("IncreaseDifficulty");
			
	}

}
