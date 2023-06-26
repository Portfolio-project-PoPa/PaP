using UnityEngine;

[RequireComponent(typeof(DeathHandler))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _healthPoints = 100f;

    private DeathHandler _deathHandler;

    private void Start()
    {
        _deathHandler = GetComponent<DeathHandler>();
    }

    public void TakeDamage(float damage)
    {
        _healthPoints -= damage;

        if (_healthPoints <= 0)
        {
            _deathHandler.Handle();
        }
    }
}
