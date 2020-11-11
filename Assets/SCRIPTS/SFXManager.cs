using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

	public AudioSource playerWalk, playerFirePistol, playerFireRifle1, playerFireRifle2, playerFireShotgun, playerPickup, 
		playerHit, playerDash;

	public GameObject followTarget;
	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
	}
}
