using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

	public GameObject EnemyBulletGO;
	// Use this for initialization
	void Start () {

		Invoke ("Fire", 1f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// shoots at player1
	void Fire()
	{
		GameObject playerShip = GameObject.Find ("Player1GO");

		if (playerShip != null) {
			GameObject bullet = (GameObject)Instantiate (EnemyBulletGO);

			bullet.transform.position = transform.position;

			Vector2 direction = playerShip.transform.position - bullet.transform.position;

			bullet.GetComponent<EnemyBullets>().SetDirection (direction);
		}
	}
}
