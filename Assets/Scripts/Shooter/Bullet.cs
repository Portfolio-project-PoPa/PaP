using System.Collections;
using System.Collections.Generic;
using Shooter;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifeDuration = 3f;

    private float _lifeTimer;

    private void OnEnable()
    {
        _lifeTimer = lifeDuration;
    }

    public int Damage { get; private set; } = 20;

    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        _lifeTimer -= Time.deltaTime;

        // When the bullet's life time exceeds, put it back in the pool
        if (_lifeTimer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
