using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPowerUp : MonoBehaviour
{
    public static RandomPowerUp Instance;

    [SerializeField] private Image icon;
    [SerializeField] private Text boostName;
    [SerializeField] private Text boostDescription;
    [SerializeField] private Text typeBoost;

    [SerializeField] private List<UpgradesInfo> boosts;
    [SerializeField] private List<WeaponInfo> weapons;

    [SerializeField] public bool updatePowerUp = false;

    public int powerUpChoise;
    private int activeBoosts;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        updatePowerUp = false;
    }

    void Update()
    {
        if (!updatePowerUp)
        {
            updatePowerUp = true;

            if (!BossDropManager.Instance.pistolActive)
                activeBoosts = boosts.Count - 2;
            else if (!!BossDropManager.Instance.shotgunActive)
                activeBoosts = boosts.Count - 1;
            else
                activeBoosts = boosts.Count;

            PowerUps();
        }
    }

    public void PowerUps()
    {
        int randomNum = Random.Range(0, activeBoosts);
        powerUpChoise = randomNum;

        icon.sprite = boosts[randomNum].upgradeIcon;

        if(randomNum == 7)
        {
            if (weapons[0].weaponLevel == 3 || weapons[0].weaponLevel == 6 || weapons[0].weaponLevel == 9)
                boosts[7].upgradeDescription = "Reduce time between slashes by 0.1";
            else
                boosts[7].upgradeDescription = "Increase the keris damage by 1";

            boostName.text = boosts[randomNum].upgradeName + " LV" + weapons[0].weaponLevel + " -> " + (weapons[0].weaponLevel + 1);
        }
        else if (randomNum == 8)
        {
            if (weapons[1].weaponLevel == 3 || weapons[1].weaponLevel == 6 || weapons[1].weaponLevel == 9)
                boosts[8].upgradeDescription = "Reduce time between shots by 0.2";
            else
                boosts[8].upgradeDescription = "Increase the pistol damage by 1";

            boostName.text = boosts[randomNum].upgradeName + " LV" + weapons[1].weaponLevel + " -> " + (weapons[1].weaponLevel + 1);
        }
        else if (randomNum == 9)
        {
            if (weapons[2].weaponLevel == 3 || weapons[2].weaponLevel == 6 || weapons[2].weaponLevel == 9)
                boosts[9].upgradeDescription = "Reduce time between shots by 0.1";
            else
                boosts[9].upgradeDescription = "Increase the shotgun damage by 1";

            boostName.text = boosts[randomNum].upgradeName + " LV" + weapons[2].weaponLevel + " -> " + (weapons[2].weaponLevel + 1);
        }
        else
        {
            boostName.text = boosts[randomNum].upgradeName;
        }

        boostDescription.text = boosts[randomNum].upgradeDescription;
        typeBoost.text = ">> " + boosts[randomNum].typeUpgrade;
    }

    public void OnClick()
    {
        switch (powerUpChoise)
        {
            case 0:
                PlayerHealth.Instance.maxHealth += 5;
                PlayerHealth.Instance.UpdateHealthSlider();
                break;
            case 1:
                PlayerController.Instance.startingMoveSpeed += 0.1f;
                break;
            case 2:
                EXPController.Instance.expGained += 5;
                break;
            case 3:
                Stamina.Instance.maxStamina += 1;
                Stamina.Instance.RefreshStamina();
                break;
            case 4:
                PlayerHealth.Instance.maxShield += 5;
                PlayerHealth.Instance.UpdateShieldSlider();
                break;
            case 5:
                PlayerHealth.Instance.addHealth += 1;
                break;
            case 6:
                PlayerHealth.Instance.addShield += 1;
                break;
            case 7:
                if (weapons[0].weaponLevel == 3 || weapons[0].weaponLevel == 6 || weapons[0].weaponLevel == 9)
                    weapons[0].weaponCooldown -= 0.1f;
                else
                    weapons[0].weaponDamage += 1;

                weapons[0].weaponLevel += 1;
                break;
            case 8:
                if (weapons[1].weaponLevel == 3 || weapons[1].weaponLevel == 6 || weapons[1].weaponLevel == 9)
                    weapons[1].weaponCooldown -= 0.2f;
                else
                    weapons[1].weaponDamage += 1;

                weapons[1].weaponLevel += 1;
                break;
            case 9:
                if (weapons[2].weaponLevel == 3 || weapons[2].weaponLevel == 6 || weapons[2].weaponLevel == 9)
                    weapons[2].weaponCooldown -= 0.1f;
                else
                    weapons[2].weaponDamage += 1;

                weapons[2].weaponLevel += 1;
                break;
        }

        ActiveWeapon.Instance.NewWeapon(ActiveWeapon.Instance.CurrentActiveWeapon);
    }
}
