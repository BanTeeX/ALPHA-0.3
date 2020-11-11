using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponPickup : MonoBehaviour {

	public bool pickable;
	public PlayerWeaponChange inventory;
	public GameObject weapon;
	public string weaponName;

	private SFXManager SFXman;

	// Use this for initialization
	void Start () {

		SFXman = FindObjectOfType<SFXManager> ();
		weaponName = "/Player/Weapon/" + weaponName;
		weapon = GameObject.Find (weaponName);
		inventory = FindObjectOfType<PlayerWeaponChange>();
		pickable = false;
	}

	// Update is called once per frame
	void Update () {

		if (pickable && inventory.pickupTime <= 0 && Input.GetAxisRaw ("Pickup") > 0.5) 
		{
			inventory.pickupTime = 0.3f;
			SFXman.playerPickup.Play ();
			if (inventory.activeWeapon.name != "Nothing")
				Instantiate (inventory.activeWeapon.GetComponent<PlayerShooting>().item, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			inventory.WeaponPickup (weapon);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
			pickable = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
			pickable = false;
	}
}
