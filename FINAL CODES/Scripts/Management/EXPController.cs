using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPController : MonoBehaviour
{
    public static EXPController Instance;

    [SerializeField] private Text levelText;

    [SerializeField] public int level = 1;
    [SerializeField] public int currentEXP;
    [SerializeField] public int targetEXP;
    [SerializeField] public int expGained = 10;

    private Slider expProgressBar;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ExperienceController();
    }

    public void ExperienceController()
    {
        levelText.text = level.ToString();
        if (expProgressBar == null)
        {
            expProgressBar = GetComponent<Slider>();
        }

        expProgressBar.maxValue = targetEXP;
        expProgressBar.value = currentEXP;

        if (currentEXP >= targetEXP) //Level Up
        {
            Debug.Log("Level Up triggered.");

            PlayerStat.Instance.UpdateStats();
            PauseGame.Instance.LevelUpMenu();

            // Reset EXP and increase level
            currentEXP = currentEXP - targetEXP;
            level++;
            targetEXP += 50;

            // Refresh weapon to keep bullet spawning active
            ActiveWeapon.Instance.RefreshWeapon();
        }
    }
}
