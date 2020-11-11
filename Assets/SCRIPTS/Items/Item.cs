using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public PlayerStats player;
	public int dropChance;
	public bool d;
	public char material;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerStats> ();

	}
	
	// Update is called once per frame0
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			if(d)
				Destroy (gameObject);
			player.AddMaterial (Random.Range (5, 10), material);
		}
	}


}
