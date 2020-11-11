using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float dashSpeed, dashTime, dashCooldown, moveSpeed, realDashTime, realDashCooldown;
	private float realMoveSpeed, mouseX, mouseY;
	public bool dash, moving;

	private Vector3 mousePosition;
	private Animator anim;
	private Rigidbody2D myRigidbody;

	private PlayerStats stats;
	private SFXManager SFXman;

	// Use this for initialization
	void Start () {

		SFXman = FindObjectOfType<SFXManager> ();
		myRigidbody = GetComponent<Rigidbody2D>();
		stats = GetComponent<PlayerStats> ();
		dash = false;
		realDashCooldown = 0;
		realMoveSpeed = moveSpeed;
		anim = GetComponent<Animator> ();

		SFXman.playerWalk.Play();
		SFXman.playerWalk.mute = true;
	}

	// Update is called once per frame
	void Update () {

		moving = false;
		SFXman.playerWalk.mute = true;

		if (Time.deltaTime > 0) 
		{
			if (realDashCooldown > 0) {
				realDashCooldown -= Time.deltaTime;
			}

			if (dash) 
			{
				realDashTime -= Time.deltaTime;
				if (realDashTime <= 0) {
					realDashTime = dashTime;
					realDashCooldown = dashCooldown;
					dash = false;
					realMoveSpeed = moveSpeed;
				}

			} else {

				if (Input.GetKey (KeyCode.LeftShift) && realDashCooldown <= 0 && stats.playerCurrentEnergy > 0) {
					realMoveSpeed = dashSpeed;
					realDashTime = dashTime;
					if (!dash) 
					{
						SFXman.playerDash.Play ();
						stats.playerCurrentEnergy--;
					}
					dash = true;
				}
			
				if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
					myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * realMoveSpeed, myRigidbody.velocity.y);
					moving = true;
					SFXman.playerWalk.mute = false;
				}

				if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
					myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * realMoveSpeed);
					moving = true;
					SFXman.playerWalk.mute = false;
				}

				if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
					myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
				}

				if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
					myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
				}
			}

			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouseX = mousePosition.x;
			mouseY = mousePosition.y;

			anim.SetFloat ("MoveX", -1);
			if (mouseX > GetComponent<Transform> ().position.x) {
				anim.SetFloat ("MoveX", 1);
			}

			anim.SetFloat ("MoveY", -1);
			if (mouseY > GetComponent<Transform> ().position.y) {
				anim.SetFloat ("MoveY", 1);
			}

			anim.SetBool ("Move", moving);


		}
	}			
}

