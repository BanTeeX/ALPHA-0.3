using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour {

	public PlayerStats player;
	public string ammoType;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerStats> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void Pickup()
	{
		
	}
}
