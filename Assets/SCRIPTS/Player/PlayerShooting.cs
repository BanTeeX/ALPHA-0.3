using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public int currentMagazine, maxMagaznie, ammo;
	public float reloadTime, timeToShoot, damageToGive, numberOfBullets, dispersion, projectileSpeed;

	public float realReloadTime, realTimeToShoot;
	public bool noReload;

	public string  soundName;
	public AudioSource sound;
	public GameObject particle, item;
	public Texture2D defaultTextue;
	public Texture2D reloadTextue;
	private CursorMode cM = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {

		sound = FindAudio (soundName);
		noReload = true;
		currentMagazine = maxMagaznie;
		hotSpot = new Vector2 (defaultTextue.width / 2, defaultTextue.height / 2);
		Cursor.SetCursor (defaultTextue, hotSpot, cM);
		realTimeToShoot = timeToShoot;

	}

	// Update is called once per frame
	void Update () {

		if (realTimeToShoot > 0) {
			realTimeToShoot -= Time.deltaTime;
		} else {
			if (currentMagazine > 0 && noReload && Time.timeScale > 0) {
				if (Input.GetAxisRaw ("Fire1") > 0.5) {
					particle.GetComponent<PlayerBullets> ().projectileSpeed = projectileSpeed;
					particle.GetComponent<PlayerBullets> ().damageToGive = damageToGive;
					particle.GetComponent<PlayerBullets> ().dispersion = dispersion;
					sound.Play();
					for (int i = 0; i < numberOfBullets; i++) {
						Instantiate (particle, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					}
					currentMagazine--;
					realTimeToShoot = timeToShoot;
				}
			}
		}

		if (currentMagazine == 0 || Input.GetAxisRaw ("Reload") > 0.5)
			noReload = false;

		if (!noReload && ammo > 0) 
		{
			noReload = false;
			realReloadTime -= Time.deltaTime;
			Cursor.SetCursor (reloadTextue, hotSpot, cM);

			if (realReloadTime < 0) {
				realReloadTime = reloadTime;
				noReload = true;
				Cursor.SetCursor (defaultTextue, hotSpot, cM);
				if (ammo > maxMagaznie) 
				{
					ammo -= maxMagaznie - currentMagazine;
					currentMagazine = maxMagaznie;
				} else 
				{
					maxMagaznie = ammo;
					ammo = 0;
				}
			}
		}

		if (currentMagazine != 0 && noReload)
			Cursor.SetCursor (defaultTextue, hotSpot, cM);

	}

	AudioSource FindAudio (string name)
	{
		return GameObject.Find ("/SFXManager/" + name).GetComponent<AudioSource> ();
	}
}


