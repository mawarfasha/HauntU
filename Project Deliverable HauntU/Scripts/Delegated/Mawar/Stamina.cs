using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : Singleton<Stamina>
{
    //MAWAR

    public int CurrentStamina {  get; private set; }

    [SerializeField] private int timeBetweenStaminaRefresh = 3;
    [SerializeField] public int maxStamina;

    private Transform staminaCounter;
    private int startingStamina = 5;
    const string STAMINA_COUNTER_TEXT = "Stamina Counter";

    protected override void Awake()
    {
        base.Awake();

        maxStamina = startingStamina;
        CurrentStamina = startingStamina;
    }

    private void Start()
    {
        FindStaminaCounter();
    }

    private void FindStaminaCounter()
    {
        staminaCounter = GameObject.Find(STAMINA_COUNTER_TEXT)?.transform;
        if (staminaCounter == null)
        {
            Debug.LogWarning("Stamina counter not found. Please ensure it exists in the scene.");
        }
    }

    public void UseStamina()
    {
        CurrentStamina--;
        UpdateStaminaImage();
    }

    public void RefreshStamina()
    {
        if(CurrentStamina < maxStamina)
            CurrentStamina++;

        UpdateStaminaImage();
    }

    private IEnumerator RefreshStaminaRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenStaminaRefresh);
            RefreshStamina();
        }
    }

    private void UpdateStaminaImage()
    {
        if (staminaCounter == null)
        {
            FindStaminaCounter();
            if (staminaCounter == null) return; // Abort if still not found
        }

        for (int i = 0; i < maxStamina; i++)
        {
            if (i <= CurrentStamina - 1)
                staminaCounter.GetChild(i).GetComponent<Image>().enabled = true;
            else
                staminaCounter.GetChild(i).GetComponent<Image>().enabled = false;
        }

        if (CurrentStamina < maxStamina)
        {
            StopAllCoroutines();
            StartCoroutine(RefreshStaminaRoutine());
        }
    }
}
