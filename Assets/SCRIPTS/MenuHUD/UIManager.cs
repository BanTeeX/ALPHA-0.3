using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar, shieldBar, energyBar;
	public Text HPText, SHText, EText, weaponName, weaponAmmo, weaponID, dashCooldown, quantityTitanium, quantityUranium, quantityGold, quantityQuartz;
	public PlayerStats playerHealth, inventory;
    public PlayerWeaponChange weapon;
    public PlayerMovement dash;
    public Image weaponImage, dashImage;

    private Canvas hud;

    // Use this for initialization
    void Start () {
        hud = (Canvas)GetComponent<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {

		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

		shieldBar.maxValue = playerHealth.playerMaxShield;
		shieldBar.value = playerHealth.playerCurrentShield;
		SHText.text = "SHIELD: " + playerHealth.playerCurrentShield + "/" + playerHealth.playerMaxShield;

		energyBar.maxValue = playerHealth.playerMaxEnergy;
		energyBar.value = playerHealth.playerCurrentEnergy;
		EText.text = "ENERGY: " + playerHealth.playerCurrentEnergy + "/" + playerHealth.playerMaxEnergy;

        weaponImage.sprite = weapon.activeWeapon.GetComponent<SpriteRenderer>().sprite;
        switch (weapon.activeWeapon.name)
        {
            case "Pistol":
                weaponName.text = "PISTOLET";
                break;
            case "Pistol2":
                weaponName.text = "PISTOLET";
                break;
            case "Shotgun":
                weaponName.text = "STRZELBA";
                break;
            case "SniperRifle":
                weaponName.text = "SNAJPERKA";
                break;
            case "AssultRifle":
                weaponName.text = "KARABIN";
                break;
            case "Rewolwer":
                weaponName.text = "REWOLWER";
                break;
            case "Nothing":
                weaponName.text = "PUSTO";
                break;
        }
        if (weapon.activeWeapon.name != "Nothing")
        {
            weaponAmmo.text = System.Convert.ToString(weapon.activeWeapon.GetComponent<PlayerShooting>().currentMagazine) + "/" + System.Convert.ToString(weapon.activeWeapon.GetComponent<PlayerShooting>().ammo);
        }
        else
        {
            weaponAmmo.text = "0/0";
        }
        weaponID.text = System.Convert.ToString(weapon.activeWeaponID);

        if(dash.dash)
        {
            Color color = new Color(1, 1, 0.2f, 1);
            dashImage.color = color;
        }
        else if(dash.realDashCooldown > 0)
        {
            Color color = new Color(1, 1, 1, 0.2f);
            dashImage.color = color;
        }
        else
        {
            Color color = new Color(1, 1, 1, 1);
            dashImage.color = color;
        }

        if(dash.realDashCooldown > 0)
        {
            dashCooldown.text = System.Convert.ToString(System.Math.Round(dash.realDashCooldown, 2));
        }
        else
        {
            dashCooldown.text = "";
        }

        quantityTitanium.text = System.Convert.ToString(inventory.titanium);
        quantityUranium.text = System.Convert.ToString(inventory.uranium);
        quantityGold.text = System.Convert.ToString(inventory.gold);
        quantityQuartz.text = System.Convert.ToString(inventory.quartz);
    }
}