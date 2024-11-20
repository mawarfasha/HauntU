using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : Singleton<PlayerStat>
{
    [SerializeField] private List<WeaponInfo> weapon;

    private Text hp, atkKeris, spd, def;

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    private void Start()
    {
        hp = GameObject.Find("Max/Current HP").GetComponent<Text>();
        def = GameObject.Find("Max/Current DEF").GetComponent<Text>();
        atkKeris = GameObject.Find("CurrrentATK").GetComponent<Text>();
        spd = GameObject.Find("CurrrentSPD").GetComponent<Text>();
    }

    public void UpdateStats()
    {
        hp.text = PlayerHealth.Instance.maxHealth.ToString() + " / " + PlayerHealth.Instance.currentHealth.ToString();
        def.text = PlayerHealth.Instance.maxShield.ToString() + " / " + PlayerHealth.Instance.currentShield.ToString();
        atkKeris.text = weapon[0].weaponDamage.ToString();
        spd.text = PlayerController.Instance.startingMoveSpeed.ToString();
    }
}
