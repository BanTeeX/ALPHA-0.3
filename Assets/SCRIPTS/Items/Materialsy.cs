using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materialsy : MonoBehaviour {

	public PlayerStats player;
	public char material;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Pickup ()
	{
		player.AddMaterial (Random.Range (5, 10), material);
	}
}
