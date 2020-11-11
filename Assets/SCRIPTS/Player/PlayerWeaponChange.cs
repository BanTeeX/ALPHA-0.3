using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponChange : MonoBehaviour {

	public GameObject weapon1, weapon2, activeWeapon;
	public int activeWeaponID;
	public float pickupTime;

	// Use this for initialization
	void Start () {

		activeWeapon = weapon1;
		Deactive ();
		activeWeapon.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {

		if (pickupTime > 0)
			pickupTime -= Time.deltaTime;

		if (Input.GetAxisRaw ("Drop") > 0 && activeWeapon != GameObject.Find ("/Player/Weapon/Nothing")) 
		{
			Instantiate (activeWeapon.GetComponent<PlayerShooting>().item, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			WeaponPickup (GameObject.Find ("/Player/Weapon/Nothing"));
			activeWeapon.SetActive (true);
		}

		if (Input.GetAxisRaw ("Weapon1") > 0.5 || Input.GetAxisRaw ("Weapon2") > 0.5) 
		{
			ActiveWeaponChange ();
			Deactive ();
			activeWeapon.SetActive (true);
		}

	}

	public void Deactive()
	{
		weapon1.SetActive (false);
		weapon2.SetActive (false);
	}
	public void Active ()
	{
		weapon1.SetActive (true);
		weapon2.SetActive (true);
	}

	public void WeaponPickup (GameObject newWeapon)	
	{
		Deactive ();
		newWeapon.SetActive (true);
		switch (activeWeaponID)
		{
		case 1:
			weapon1 = newWeapon;
			break;
		case 2:
			weapon2 = newWeapon;
			break;
		}
		activeWeapon = newWeapon;
		activeWeapon.SetActive (true);
	}

	public void ActiveWeaponChange ()
	{
		if (Input.GetAxisRaw ("Weapon1") == 1)
		{	
			activeWeapon = weapon1;
			activeWeaponID = 1;
		}
		if (Input.GetAxisRaw ("Weapon2") == 1)
		{	
			activeWeapon = weapon2;
			activeWeaponID = 2;
		}
	}
}
