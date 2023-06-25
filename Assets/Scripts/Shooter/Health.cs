using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _value = 100;
    private int _maxValue = 100;
    
    private void OnCollisionEnter(Collision damagingObject)
    {
        if (damagingObject.collider.TryGetComponent(out Bullet bullet))
        {
            TakeDamage(bullet.Damage);
        }
    }

    private void TakeDamage(int damage)
    {
        _value -= damage;

        if (_value <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
