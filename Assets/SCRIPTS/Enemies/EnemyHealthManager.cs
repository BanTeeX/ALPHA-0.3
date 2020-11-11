using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
	
	public float MaxHealth;
	public float CurrentHealth;
	public Item[] drop;

	// Use this for initialization
	void Start () {

		SetMaxHealth ();
	}

	// Update is called once per frame
	void Update () {
			

		if (CurrentHealth <= 0) 
		{
			Drop ();
			Destroy (gameObject);
		}
	}

	public void Hurt(float damageToGive)
	{
		CurrentHealth -= damageToGive;
	}


	public void SetMaxHealth()
	{
		CurrentHealth = MaxHealth;
	}

	public void Drop ()
	{
		for(int i = 0; i < drop.Length; i++)
			if(Random.Range(0, 100) < drop[i].dropChance)
				Instantiate (drop[i], new Vector3 (transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), transform.position.z), Quaternion.identity);
	}

}
