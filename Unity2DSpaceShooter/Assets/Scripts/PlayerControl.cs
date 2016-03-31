using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public GameObject Player1BulletGO;
	public GameObject BulletPos01;
	public GameObject BulletPos02;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("space")) 
		{
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
}
