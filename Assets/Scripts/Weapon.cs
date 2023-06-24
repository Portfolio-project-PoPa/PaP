using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _FPCamera;
    [SerializeField] float _range;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out RaycastHit hit, _range);
        Debug.Log(hit.collider.name);
    }
}
