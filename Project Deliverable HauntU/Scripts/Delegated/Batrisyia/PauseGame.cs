using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : Singleton<PauseGame>
{
    //BATRISYIA

    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject newWeaponMenu;
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        upgradeMenu.SetActive(false);
        newWeaponMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
            {
                PauseMenu();
            }
        }
    }

    public void LevelUpMenu()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void AllResume()
    {
        newWeaponMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
