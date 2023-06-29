using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _healthPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");

        _healthPoints -= damage;

        if (_healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead)
            return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
