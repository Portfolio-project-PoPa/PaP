using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _shotDelay = 0.5f;

    [SerializeField] private Camera _FPCamera;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _hitImpact;
    [SerializeField] private Ammo _ammoSlot;

    [SerializeField] private AmmoType _ammoType;

    private bool _canShoot = true;

    private void OnEnable()
    {
        _canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        _canShoot = false;

        if (_ammoSlot.GetCurrentAmount(_ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            _ammoSlot.ReduceCurrentAmount(_ammoType);
        }

        yield return new WaitForSeconds(_shotDelay);
        _canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
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
        GameObject hitEffect = Instantiate(_hitImpact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffect, 0.1f);
    }
}
