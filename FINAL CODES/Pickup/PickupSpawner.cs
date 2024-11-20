using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject stamina, exp, healthKit, pill;
    [SerializeField] private GameObject newWeaponBox;

    public void DropItem()
    {
        int randomNum = Random.Range(1, 8);

        if (randomNum == 1 || randomNum == 3)
            Instantiate(stamina, transform.position, Quaternion.identity);

        if (randomNum == 2 || randomNum == 4)
            Instantiate(healthKit, transform.position, Quaternion.identity);

        if (randomNum == 5 || randomNum == 7)
            Instantiate(pill, transform.position, Quaternion.identity);
    }

    public void DropItemForEnemy()
    {
        int randomNum = Random.Range(1, 8);

        if (randomNum == 3)
            Instantiate(stamina, transform.position, Quaternion.identity);

        if (randomNum == 4)
            Instantiate(healthKit, transform.position, Quaternion.identity);

        if (randomNum == 7)
            Instantiate(pill, transform.position, Quaternion.identity);
    }

    public void DropEXP()
    {
        Instantiate(exp, transform.position, Quaternion.identity);
    }

    public void BossDrop(int bossHealth)
    {
        for (int i = 0; i < bossHealth/2; i++)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
        }
        Instantiate(newWeaponBox, transform.position, Quaternion.identity);
    }
}
