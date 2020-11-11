using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	public PlayerMovement player;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerMovement>();
		SpawnPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnPlayer () 
	{
		player.transform.position = transform.position;
	}
}
