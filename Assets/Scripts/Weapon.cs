using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _FPCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] private float _damage = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out RaycastHit hit, _range))
        {
            if(hit.collider.TryGetComponent(out EnemyHealth target))
            {
                target.TakeDamage(_damage);
            }

            Debug.Log(hit.collider.name);
        }
        else
        {
            return;
        }
    }
}
