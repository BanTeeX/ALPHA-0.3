using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour {

	private PlayerMovement player;

	public bool triggered, shooting;
	public float triggerRadius, timeToShoot;
	public float x, y, realTimeToShoot;

	private Rigidbody2D myRigidbody;
	private Animator anim;

	public Object[] bullets;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody2D>();
		player = FindObjectOfType<PlayerMovement> ();
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		x = player.transform.position.x - transform.position.x;
		y = player.transform.position.y - transform.position.y;

		if ((Mathf.Sqrt (x * x + y * y) < triggerRadius))
			triggered = true;
		else 
			triggered = false;

		if (triggered) 
		{
			if (realTimeToShoot < 0) {
				anim.SetBool ("Shoot", true); 
				for (int i = 0; i < 8; i++)
					Instantiate (bullets [i], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
				realTimeToShoot = timeToShoot;
				shooting = true;
			} else {
				realTimeToShoot -= Time.deltaTime;
				shooting = false;
				anim.SetBool ("Shoot", false); 
			}
		}

	}
}
