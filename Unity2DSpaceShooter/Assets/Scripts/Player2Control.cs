using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour {

	public GameObject GameManagerGO;
	GameObject scoreUITextGO;
	public float speed;
	public float count;
	// Use this for initialization
	void Start () {
	
		scoreUITextGO = GameObject.FindGameObjectWithTag ("ScoreTextTag");
	}

	public void Init()
	{
		//transform.position = new Vector2 (0, 0);
		gameObject.SetActive (true);
		transform.position = new Vector2 (0f, -2.823149f);
	}

	public void End()
	{
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.KeypadPlus)) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.KeypadMinus)) {
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.KeypadEnter)) {
			if (count >= 10) {
				speed++;
				count = 0;
			}
		}

	}
		
	void OnTriggerEnter2D(Collider2D col)
	{
		if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
		{
			scoreUITextGO.GetComponent<GameScore> ().Score += 150;
			count++;
		}
	}
}
