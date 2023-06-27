using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _FPCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] private float _damage = 20f;
    [SerializeField] private ParticleSystem _muzzleEffect;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private Ammo _ammoSlot;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_ammoSlot.GetCurrentAmount() > 0)
        {
            ProcessShootingParticles();
            ProcessRaycast();
            _ammoSlot.ReduceCurrentAmount();
        }
    }

    private void ProcessShootingParticles()
    {
        _muzzleEffect.Play();
    }

    private void ProcessRaycast()
    {
        if (Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out RaycastHit hit, _range))
        {
            CreateHitImpact(hit);

            if (hit.collider.TryGetComponent(out EnemyHealth target))
                target.TakeDamage(_damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject hitEffect = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffect, 0.1f);
    }
}
