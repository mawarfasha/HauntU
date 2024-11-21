using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    //MAWAR

    public bool isDead {  get; private set; }

    [Header("Health")]
    [SerializeField] public int maxHealth = 3;
    [SerializeField] public int currentHealth;
    [SerializeField] public int addHealth = 1;

    [Header("Shield")]
    [SerializeField] public int maxShield;
    [SerializeField] public int currentShield;
    [SerializeField] public int addShield = 1;

    [Header("Kill Count")]
    [SerializeField] public int killCount = 0;

    [Header("Other Realated")]
    [SerializeField] private float knockedBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] public GameObject deathScreen;

    private Slider healthSlider;
    private Slider shieldSlider;
    private bool canTakeDamage = true;
    private Knockback knockback;
    private Flash flash;

    readonly int DEATH_HASH = Animator.StringToHash("Death");

    protected override void Awake()
    {
        //base.Awake();

        deathScreen = GameObject.Find("DeathScreen");

        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        isDead = false; 
        currentHealth = maxHealth;
        maxShield = maxHealth;
        currentShield = 0;

        deathScreen.SetActive(false);

        UpdateHealthSlider();
        UpdateShieldSlider();
    }

    private void Update()
    {
        UpdateHealthSlider();
        UpdateShieldSlider();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyFollow enemy = other.gameObject.GetComponent<EnemyFollow>();

        if (enemy)
        {
            TakeDamage(enemy.damageDealt, other.transform);
        }
    }

    public void HealPlayer()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += addHealth;
            UpdateHealthSlider();
        }
    }

    public void ShieldPlayer()
    {
        if (currentShield < maxShield)
        {
            currentShield += addShield;
            UpdateShieldSlider();
        }
    }

    private void TakeDamage(int damageAmount, Transform hitTransform)
    {
        if(!canTakeDamage) { return; }

        ScreenShakeManager.Instance.ShakeScreen();
        knockback.GetKnockedBack(hitTransform, knockedBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;

        if (currentShield != 0)
        {
            currentShield -= damageAmount;
            UpdateShieldSlider();
        }else
        {
            currentHealth -= damageAmount;
            UpdateHealthSlider();
        }

        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealthSlider();
        CheckIfPlayerDeath();
    }

    private void CheckIfPlayerDeath()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            //Destroy(ActiveWeapon.Instance.gameObject);
            currentHealth = 0;
            GetComponent<Animator>().SetTrigger(DEATH_HASH);
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    public void UpdateHealthSlider()
    {
        if (healthSlider == null)
        {
            healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void UpdateShieldSlider()
    {
        if (shieldSlider == null)
        {
            shieldSlider = GameObject.Find("ShieldBar").GetComponent<Slider>();
        }

        shieldSlider.maxValue = maxShield;
        shieldSlider.value = currentShield;
    }

    public void ResetInstance()
    {
        killCount = 0;
        maxHealth = 10;
        maxShield = 10;
        currentShield = 0;
        addHealth = 1;
        addShield = 1;
        currentHealth = maxHealth;
        isDead = false;
        deathScreen.SetActive(false);  // Hide the death screen
        UpdateHealthSlider();
        UpdateShieldSlider();
    }
}
