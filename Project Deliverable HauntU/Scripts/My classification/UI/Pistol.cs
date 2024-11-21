using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bulletPrefeb;
    [SerializeField] private Transform bulletSpawnPoint;

    readonly int FIRE_HASH = Animator.StringToHash("Fire");

    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Attack()
    {
        /*myAnimator.SetTrigger(FIRE_HASH);
        Debug.Log("Bullet instantiated.");
        GameObject newBullet = Instantiate(bulletPrefeb, bulletSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
        newBullet.GetComponent<Projectiles>().UpdateWeaponInfo(weaponInfo);*/

        Debug.Log("Attempting to instantiate bullet prefab...");
        myAnimator.SetTrigger(FIRE_HASH);

        GameObject newBullet = Instantiate(bulletPrefeb, bulletSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);

        if (newBullet != null)
        {
            newBullet.GetComponent<Projectiles>().UpdateWeaponInfo(weaponInfo);
            Debug.Log("Bullet instantiated successfully at position: " + bulletSpawnPoint.position);
        }
        else
        {
            Debug.LogError("Bullet instantiation failed!");
        }
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
