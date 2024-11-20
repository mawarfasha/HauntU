using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen instance;

    [SerializeField] private Text actualTimer;
    [SerializeField] private Text timeText, levelText, killText;
    [SerializeField] private List<WeaponInfo> weapons;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = actualTimer.text;
        levelText.text = "LV " + EXPController.Instance.level.ToString();
        killText.text = PlayerHealth.Instance.killCount.ToString();
    }

    public void Reset()
    {
        weapons[0].weaponLevel = 1;
        weapons[0].weaponCooldown = 0.7f;
        weapons[0].weaponDamage = 1;
        weapons[0].weaponRange = 0;

        weapons[1].weaponLevel = 1;
        weapons[1].weaponCooldown = 1;
        weapons[1].weaponDamage = 2;
        weapons[1].weaponRange = 12;

        weapons[2].weaponLevel = 1;
        weapons[2].weaponCooldown = 1.2f;
        weapons[2].weaponDamage = 4;
        weapons[2].weaponRange = 8;

        /*Stamina.Instance.maxStamina = 5;
        Stamina.Instance.RefreshStamina();
        EXPController.Instance.expGained = 10;

        WaveSpawner.Instance.spawnRate = 3.0f;
        WaveSpawner.Instance.timeBetweenWaves = 5.0f;
        WaveSpawner.Instance.enemyCount = 5;
        WaveSpawner.Instance.waveCount = 1;
        WaveSpawner.Instance.bossWaveCount = 0;
        WaveSpawner.Instance.bossWave = 4;*/

        PlayerController.Instance.ResetInstance();
        PlayerHealth.Instance.ResetInstance();

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;

        gameObject.SetActive(false);
    }

    public void Home()
    {
        weapons[0].weaponLevel = 1;
        weapons[0].weaponCooldown = 0.7f;
        weapons[0].weaponDamage = 1;
        weapons[0].weaponRange = 0;

        weapons[1].weaponLevel = 1;
        weapons[1].weaponCooldown = 1;
        weapons[1].weaponDamage = 2;
        weapons[1].weaponRange = 12;

        weapons[2].weaponLevel = 1;
        weapons[2].weaponCooldown = 1.2f;
        weapons[2].weaponDamage = 4;
        weapons[2].weaponRange = 8;

        PlayerController.Instance.ResetInstance();
        PlayerHealth.Instance.ResetInstance();

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        Time.timeScale = 1f;
    }
}
