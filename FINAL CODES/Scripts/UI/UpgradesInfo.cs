using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Upgrade")]
public class UpgradesInfo : ScriptableObject
{
    public Sprite upgradeIcon;
    public string upgradeName;
    public string upgradeDescription;
    public string typeUpgrade;
}
