using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _healthPoints = 100f;

    private void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        _healthPoints -= damage;

        if (_healthPoints <= 0)
        {
            
        }
    }
}
