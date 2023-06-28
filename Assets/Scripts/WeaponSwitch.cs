using System;
using UnityEngine;
using UnityEngine.AI;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private int _currenWeapon = 0;

    void Start()
    {
        SetWeaponActive();    
    }

    void Update()
    {
        int previousWeapon = _currenWeapon;
        ProcessKeyInput();
        //ProcessScrollWheel();

        if(previousWeapon != _currenWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        throw new NotImplementedException();
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currenWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currenWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currenWeapon = 2;
        }
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

}
