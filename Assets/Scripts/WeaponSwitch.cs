using System;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private int _currenWeapon = 0;

    void Start()
    {
        SetWeaponActive();    
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if(weaponIndex == _currenWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }

    void Update()
    {
        
    }
}
