using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class WeaponInfo : ScriptableObject
{
    public GameObject weaponPrefeb;
    public int weaponLevel;
    public float weaponCooldown;
    public int weaponDamage;
    public float weaponRange;
}
