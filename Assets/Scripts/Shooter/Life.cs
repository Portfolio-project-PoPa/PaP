using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    private void OnCollisionEnter(Collision damagingObject)
    {
        if (damagingObject.collider.TryGetComponent(out Bullet bullet))
        {
            TakeDamage(bullet.Damage);
        }
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;

        Debug.Log("GetDamage" + damage + " Have health " + _health);
        
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
