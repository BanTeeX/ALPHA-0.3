using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	public int childID;
	public GameObject target;

	private Rigidbody2D myRigidbody;

	public float x, y;
	public float projectileSpeed, timeToDestroy, damageToGive, dispersion;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody2D> ();

		target = transform.parent.transform.GetChild (childID).gameObject;

		x = target.transform.position.x - transform.position.x;
		y = target.transform.position.y - transform.position.y;

		myRigidbody.velocity = new Vector2 (x / (Mathf.Abs (x) + Mathf.Abs (y)) * projectileSpeed, y / (Mathf.Abs (x) + Mathf.Abs (y)) * projectileSpeed);

		transform.parent = null;

		Destroy (gameObject, timeToDestroy);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag != "Enemy")
		{
			if (other.gameObject.tag != "Bullet") 
			{
				if (other.gameObject.tag != "Item")
				{
					if (other.gameObject.name == "Player") 
					{
						other.gameObject.GetComponent<PlayerStats> ().HurtPlayer (damageToGive);
					}
				}
				Destroy (gameObject);
			}
		}
	}
}

