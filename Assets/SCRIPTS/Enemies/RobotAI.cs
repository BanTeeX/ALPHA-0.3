using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAI : MonoBehaviour {

	private PlayerMovement player;

	public Object bulletType;

	public bool triggered, shooting;
	public float triggerRadius, moveSpeed, shootingRange, timeToShoot, projectileSpeed;
	private float x, x1, y, y1, realTimeToShoot;

	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody2D>();
		player = FindObjectOfType<PlayerMovement> ();

		realTimeToShoot = timeToShoot;
	}

	// Update is called once per frame
	void Update () {

		if ((Mathf.Sqrt (x * x + y * y) < triggerRadius)) {
			triggered = true;
		} else {
			triggered = false;
		}



		if ((Mathf.Sqrt (x * x + y * y) < shootingRange)) {
			shooting = true;
		} else {
			shooting = false;
		}

		x = player.transform.position.x - transform.position.x;
		y = player.transform.position.y - transform.position.y;

		if (triggered && !shooting) {
			myRigidbody.velocity = new Vector2 (x / (Mathf.Abs (x) + Mathf.Abs (y)) * moveSpeed, y / (Mathf.Abs (x) + Mathf.Abs (y)) * moveSpeed);
		} else if (shooting) {
			myRigidbody.velocity = new Vector2 (0f, 0f);
			if (realTimeToShoot < 0) {
				Instantiate (bulletType, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
				realTimeToShoot = timeToShoot;
			}
			realTimeToShoot -= Time.deltaTime;
		} else {
			myRigidbody.velocity = new Vector2 (0f, 0f);
		}

	}
}
