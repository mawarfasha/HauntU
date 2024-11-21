using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDropManager : MonoBehaviour
{
    public static BossDropManager Instance;

    [SerializeField] public List<WeaponInfo> newWeapon;
    [SerializeField] public List<InventorySlot> slot;
    [SerializeField] public bool pistolActive;
    [SerializeField] public bool shotgunActive;

    [SerializeField] private List<GameObject> inventoryImage;
    [SerializeField] private GameObject newWeaponScreen;
    [SerializeField] private Image weaponImage;

    private int weaponCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        newWeaponScreen.SetActive(false);
        pistolActive = false;
        shotgunActive = false;
    }

    public void DetectBossDrop()
    {
        newWeaponScreen.SetActive(true);
        slot[weaponCount].weaponInfo = newWeapon[weaponCount];
        weaponImage.sprite = newWeapon[weaponCount].weaponPrefeb.GetComponent<SpriteRenderer>().sprite;
        inventoryImage[weaponCount].SetActive(true);
        weaponCount++;
        Time.timeScale = 0f;

        if (weaponCount == 1)
            pistolActive = true;
        else if (weaponCount == 2)
            shotgunActive= true;
    }
}
