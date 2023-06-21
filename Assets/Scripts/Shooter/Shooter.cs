using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private int bulletPoolSize = 20;
    
        private Queue<Bullet> _bulletPool;

        private void Start()
        {
            _bulletPool = new Queue<Bullet>();
        
            for(int i = 0; i < bulletPoolSize; i++)
            {
                CreateNewBullet();
            }
        }
    
        private void Update()
        {
            if(Input.GetButtonDown("Fire1")) // Fire1 is by default the left mouse button.
            {
                Shoot();
            }
        }
        
        private void CreateNewBullet()
        {
            GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bulletObject.gameObject.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }

        private void Shoot()
        {
            if (_bulletPool.Count == 0)
            {
                CreateNewBullet();
            }

            Bullet bullet = _bulletPool.Dequeue();
        
            Transform bulletTransform = bullet.transform;
            
            bulletTransform.position = bulletSpawnPoint.position;
            bulletTransform.rotation = bulletSpawnPoint.rotation;
            bullet.gameObject.SetActive(true);

            StartCoroutine(ReturnBulletToPool(bullet, 2f));
        }

        private IEnumerator ReturnBulletToPool(Bullet bullet, float delay)
        {
            yield return new WaitForSeconds(delay);

            bullet.gameObject.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }
    }
}
