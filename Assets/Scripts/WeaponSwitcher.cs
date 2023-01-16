using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int currentWeapon;

    private StarterAssetsInputs starterAssetsInputs;

    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();

        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if (starterAssetsInputs.weaponSwitch1)
        {
            currentWeapon = 0;
        }
        if (starterAssetsInputs.weaponSwitch2)
        {
            currentWeapon = 1;
        }
        if (starterAssetsInputs.weaponSwitch3)
        {
            currentWeapon = 2;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
        starterAssetsInputs.weaponSwitch1 = false;
        starterAssetsInputs.weaponSwitch2 = false;
        starterAssetsInputs.weaponSwitch3 = false;
        starterAssetsInputs.shoot = false;
    }
}
