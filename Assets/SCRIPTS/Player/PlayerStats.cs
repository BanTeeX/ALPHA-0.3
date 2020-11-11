using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public float playerMaxHealth, playerCurrentHealth, playerMaxShield, playerCurrentShield, playerRealCurrentShield,
	playerCurrentEnergy, playerMaxEnergy, shieldRegenCD, realShieldRegenCD, shieldRegenTime, realShieldRegenTime;
	public int titanium, uranium, gold, quartz;

	private SFXManager SFXman;

	// Use this for initialization
	void Start () {

		SFXman = FindObjectOfType<SFXManager> ();

		SetMaxHealth ();
		SetMaxEnergy ();
		SetMaxShield ();

		realShieldRegenCD = shieldRegenCD;
		realShieldRegenTime = shieldRegenTime;
	}
	
	// Update is called once per frame
	void Update () {

		if (realShieldRegenCD >= 0)
			realShieldRegenCD -= Time.deltaTime * 3;
		else if (playerCurrentShield > 0 && playerCurrentShield < playerMaxShield && playerCurrentEnergy > 20) 
		{
			realShieldRegenTime -= Time.deltaTime;
			if (realShieldRegenTime <= 0) 
			{
				if (playerCurrentShield + 5 > playerMaxShield) 
				{
					SetMaxShield ();
					playerCurrentEnergy--;
				}
				else 
				{
					playerCurrentShield += 5;
					playerRealCurrentShield += 5;
					playerCurrentEnergy--;
				}
				realShieldRegenTime = shieldRegenTime;
			}
		} 
		else if (playerCurrentShield == 0 && playerCurrentEnergy > 20) 
		{
			realShieldRegenTime -= Time.deltaTime;
			if (realShieldRegenTime <= 0) 
			{
				SetMaxShield ();
				playerCurrentEnergy -= 10;
				realShieldRegenTime = shieldRegenTime;
			}
		}
			
		if (playerCurrentHealth <= 0) 
		{
			gameObject.SetActive (false);
			FindObjectOfType<SpawnPoint>().SpawnPlayer ();
			SetMaxHealth ();
			SetMaxEnergy ();
			SetMaxShield ();
			gameObject.SetActive (true);
		}
	}

	public void HurtPlayer(float damageToGive)
	{
		realShieldRegenCD = shieldRegenCD;
		playerRealCurrentShield -= damageToGive;

		if (playerRealCurrentShield < 0) 
		{
			playerCurrentShield = 0;
			playerCurrentHealth += playerRealCurrentShield;
		} else {
			playerCurrentShield = playerRealCurrentShield;
		}
		playerRealCurrentShield = playerCurrentShield;

		SFXman.playerHit.Play();
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}

	public void SetMaxShield()
	{
		playerRealCurrentShield = playerMaxShield;
		playerCurrentShield = playerMaxShield;
	}

	public void SetMaxEnergy()
	{
		playerCurrentEnergy = playerMaxEnergy;
	}

	public void AddMaterial(int n, char material)
	{
		switch (material) 
		{
		case 't':
			titanium += n;
			break;
		case 'u':
			uranium += n;
			break;
		case 'g':
			gold += n;
			break;
		case 'q':
			quartz += n;
			break;
		}
	}
}
