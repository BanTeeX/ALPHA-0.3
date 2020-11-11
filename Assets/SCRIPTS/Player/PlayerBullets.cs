using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour {

	private PlayerMovement player;

	private Rigidbody2D myRigidbody;

	private Vector3 position;

	private float x, y;
	public float projectileSpeed, timeToDestroy, damageToGive, dispersion;

	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<PlayerMovement> ();

		myRigidbody = GetComponent<Rigidbody2D> ();

		position = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		x = position.x - transform.position.x;
		y = position.y - transform.position.y;

		myRigidbody.velocity = new Vector2 (x / (Mathf.Abs (x) + Mathf.Abs (y)) * projectileSpeed + Random.Range(-dispersion, dispersion) / 10, y / (Mathf.Abs (x) + Mathf.Abs (y)) * projectileSpeed + Random.Range(-dispersion, dispersion) / 10);

		Destroy (gameObject, timeToDestroy);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.name != "Player") 
		{
			if (other.gameObject.tag != "Bullet") 
			{
				if (other.gameObject.tag != "Item") 
				{
					if (other.gameObject.tag == "Enemy") 
					{
						other.gameObject.GetComponent<EnemyHealthManager> ().Hurt (damageToGive);
					}
					Destroy (gameObject);
				}
			}
		}
	}
}

