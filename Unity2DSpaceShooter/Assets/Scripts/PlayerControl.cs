using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public GameObject GameManagerGO;
	public float speed;
	public GameObject Player1BulletGO;
	public GameObject BulletPos01;
	public GameObject BulletPos02;
	public GameObject ExplosionGO;
	public AudioClip shootSound;

	public Text LivesUIText;

	const int MaxLives = 3;
	public int lives;

	private AudioSource source;

	// on object initiation setup
	public void Init()
	{
		lives = MaxLives;
		LivesUIText.text = lives.ToString ();
		transform.position = new Vector2 (0, 0);
		gameObject.SetActive (true);
		source = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// control key inputs for shooting and movements
		if (Input.GetKeyDown ("space")) 
		{
			source.PlayOneShot (shootSound, 1f);

			GameObject bullet01 = (GameObject)Instantiate (Player1BulletGO);
			bullet01.transform.position = BulletPos01.transform.position;

			GameObject bullet02 = (GameObject)Instantiate (Player1BulletGO);
			bullet02.transform.position = BulletPos02.transform.position;
				
		}

		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		Vector2 direction = new Vector2 (x, y).normalized;
		Move (direction);
	}

	// Move the player, and keep within frame
	void Move(Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.150f;
		min.x = min.x - 0.150f;

		min.y = min.y - 0.190f;
		max.y = max.y - 0.190f;

		Vector2 pos = transform.position;
		pos += direction * speed * Time.deltaTime;

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}

	// collisions
	void OnTriggerEnter2D(Collider2D col)
	{
		if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
		{
			PlayExplosion ();

			lives--;
			LivesUIText.text = lives.ToString ();
			if (lives == 0) {

				GameManagerGO.GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.GameOver);
				gameObject.SetActive (false);
			}
		}
	}

	// explosion prefab on hit
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGO);
		explosion.transform.position = transform.position;
	}

	public void IncreaseLives()
	{
		lives++;
	}
}
