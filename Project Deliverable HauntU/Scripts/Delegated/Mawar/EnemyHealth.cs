using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //MAWAR

    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefeb;
    [SerializeField] private float knockedBackThrust = 15f;
    [SerializeField] private bool isBoss;

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockedBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    public void DetectDeath()
    {
        if(currentHealth <= 0)
        {
            Instantiate(deathVFXPrefeb, transform.position, Quaternion.identity);
            if (!isBoss)
            {
                GetComponent<PickupSpawner>().DropEXP();
                GetComponent<PickupSpawner>().DropItemForEnemy();
            }
            else
            {
                GetComponent<PickupSpawner>().BossDrop(startingHealth);
            }
            PlayerHealth.Instance.killCount += 1;
            Destroy(gameObject);
        }
    }
}
