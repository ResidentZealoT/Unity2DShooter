using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour {

	public GameObject GameManagerGO;
	GameObject scoreUITextGO;
	public PlayerControl other;
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
		
	// on collision provide lives to player1
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "EnemyShipTag")
		{
			other.lives++;
			other.LivesUIText.text = other.lives.ToString ();
			count++;
		}
	}
}
