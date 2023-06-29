using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float _damage = 40f;

    Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<PlayerHealth>().transform;
    }

    public void AttackHitEvent()
    {
        if (_target == null) return;

        _target.GetComponent<PlayerHealth>().TakeDamage(_damage);
    }
}