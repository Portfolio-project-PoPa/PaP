using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _healthPoints = 100f;

    public void TakeDamage(float damage)
    {
        _healthPoints -= damage;

        if(_healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
